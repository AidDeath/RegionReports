using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Exceptions;
using RegionReports.Data.Interfaces;
using RegionReports.Exceptions;

namespace RegionReports.Services
{
    public class UserService
    {
        private readonly string _currentUserName;
        private readonly HttpContext _httpContext;
        private readonly IDbAccessor _database;
        public UserService(IHttpContextAccessor httpContextAccessor, IDbAccessor database)
        {
            _currentUserName = httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? throw new UserIdentityRetrreivalException();
            _httpContext = httpContextAccessor.HttpContext;
            _database = database;
        }

        /// <summary>
        /// Получить системное имя пользователя
        /// </summary>
        /// <returns>Системное имя пользователя</returns>
        public string GetCurrentUserName()
        {
            return _currentUserName;
        }

        /// <summary>
        /// Получтиь из БД модель пользователя
        /// </summary>
        /// <returns>Объект ReportUser текущего пользователя</returns>
        public ReportUser GetCurrentUserModel()
        {
            return _database.ReportUsers.Get(_currentUserName);
        }

        /// <summary>
        /// Проверить, что текущий пользователь занесен в БД. Если нет - занести пустого
        /// </summary>
        /// <returns></returns>
        public async Task EnsureUserCreated()
        {
            if (!_database.ReportUsers.GetQueryable().Any(u => u.WindowsUserName == _currentUserName))
                await _database.ReportUsers.CreateAsync(new ReportUser { WindowsUserName = _currentUserName });

        }

        /// <summary>
        /// Получить модель ползьователя с его заявками на изменение данных, и предлагаемыми изменениями
        /// </summary>
        /// <returns>Объект ReportUser текущего пользователя</returns>
        public ReportUser GetCurrentUserWithClaims()
        {

            var userModel = _database.ReportUsers.GetQueryable()
                .Where(u => u.WindowsUserName == _currentUserName)
                .Include(u => u.RelatedDistrict)
                .Include(u => u.UserApprovalClaims)
                .ThenInclude(c => c.ReportUserSuggestedChanges).ThenInclude(changes => changes.RelatedDistrict)
                .FirstOrDefault();

            return userModel;
        }

        /// <summary>
        /// Получить модель ползьователя с его заявками на изменение данных, и предлагаемыми изменениями
        /// </summary>
        /// <returns>Объект ReportUser текущего пользователя</returns>
        public async Task<ReportUser> GetCurrentUserWithClaimsAsync()
        {

            var userModel = await _database.ReportUsers.GetQueryable()
                .Where(u => u.WindowsUserName == _currentUserName)
                .Include(u => u.RelatedDistrict)
                .Include(u => u.UserApprovalClaims)
                .ThenInclude(c => c.ReportUserSuggestedChanges)
                .FirstOrDefaultAsync();

            return userModel;
        }

        /// <summary>
        /// проверить принадлежность пользователя к роли
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool IsUserInRole(string roleName)
        {
            return _httpContext.User.IsInRole(roleName);
        }

        /// <summary>
        /// Получить список SID групп пользователя и вернуть, преобразовав в понятные название групп
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserRoleList()
        {
            List<string> result = new List<string>();
            var groupSids = _httpContext.User.Claims
                .Where(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid")
                .Select(c => c.Value);

            if (groupSids is null) return result;

            foreach (var groupSid in groupSids)
            {

                try
                {
                    result.Add(new System.Security.Principal.SecurityIdentifier(groupSid).Translate(typeof(System.Security.Principal.NTAccount)).ToString());
                }
                catch (Exception)
                {
                    continue;
                }
                    
            }

            return result;
        }

        public bool IsCurrentUserAproved()
        {
            return GetCurrentUserModel().IsApproved;
        }

        /// <summary>
        /// Создание новой заявки на изменение данных пользователя
        /// </summary>
        /// <param name="actualUser"></param>
        /// <param name="tempData"></param>
        /// <returns></returns>
        public ReportUser CreateNewApprovalClaim(ReportUser? actualUser, ReportUser tempData)
        {

            if (actualUser is null) actualUser = GetCurrentUserModel();

            var newClaim = new ReportUserApprovalClaim
            {
                ReportUser = actualUser,
                ReportUserSuggestedChanges = new ReportUserSuggestedChanges
                {
                    FullName = tempData.FullName,
                    Email = tempData.Email,
                    RelatedDistrict = tempData.RelatedDistrict
                }
            };

            actualUser.PreviousApprovalState = actualUser.IsApproved;
            actualUser.IsApproved = false;

            _database.ReportUserApprovalClaims.Create(newClaim);

            //Оказывается - не нужно. EF сам справился
            //if (actualUser.UserApprovalClaims is null) 
            //    actualUser.UserApprovalClaims = new();
            //actualUser.UserApprovalClaims.Add(newClaim);

            return actualUser;
        }

        public bool RevokeApprovalClaim(ReportUserApprovalClaim claim) 
        {
            try
            {
                var previousState = claim.ReportUser.PreviousApprovalState;

                claim.ReportUser.PreviousApprovalState = claim.ReportUser.IsApproved;

                claim.ReportUser.IsApproved = previousState ?? false;

                claim.IsClaimProcessed = true;

                _database.ReportUserApprovalClaims.Update(claim);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TODO
        //- Метод для тестирования разного рода штук. Удалить потом.
        public void TestMethod()
        {
            var user = GetCurrentUserWithClaims();

            var newClaim = new ReportUserApprovalClaim
            {
                ReportUser = user,
                ReportUserSuggestedChanges = new ReportUserSuggestedChanges
                {
                    FullName = "fsdfsadf",
                    RelatedDistrict = _database.Districts.Get(3),
                }
            };

            newClaim.ReportUser.IsApproved = false;

            _database.ReportUserApprovalClaims.Create(newClaim);

        }

        /// <summary>
        /// Получить полный список пользователей с районами
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReportUser> GetAllUsersWithDistricts(bool approvedOnly = false)
        {
            if (approvedOnly) return _database.ReportUsers.GetQueryable().Where(u => u.IsApproved ).Include(u => u.RelatedDistrict).OrderBy(u => u.FullName).AsEnumerable();

            return _database.ReportUsers.GetQueryable().Include(u => u.RelatedDistrict).OrderBy(u => u.FullName).AsEnumerable();
        }

        public void DeleteUserRecord(ReportUser user)
        {
            if (user.WindowsUserName != GetCurrentUserModel().WindowsUserName)
                _database.ReportUsers.Delete(user);
        }
    }
}
