using RegionReports.Data.Interfaces;
using RegionReports.Data.Entities;
using RegionReports.Data;

namespace RegionReports.Services
{
    public class SettingsService
    {
        private IConfiguration _configuration;
        private IDbAccessor _database;
        private readonly RegionReportsContext _dbContext;

        public SettingsService(IConfiguration configuration, IDbAccessor database, RegionReportsContext dbContext)
        {
            _configuration = configuration;
            _database = database;
            _dbContext = dbContext;
        }

        public string GetFileStoragePath() => _configuration.GetSection("FileStorageSettings").GetValue<string>("FileStoragePath");

        public long GetMaxUploadFileSize() => _configuration.GetSection("FileStorageSettings").GetValue<int>("MaxUploadFileSize");

        public string GetUploadableMimeTypes()
        {
            var a = _database.UploadableFileTypes.GetQueryable();
            return a.ToList().Select(mime => mime.AlowedMimeType).Aggregate((s1, s2) => s1 + ',' + s2);

        }

        public List<AccessRole> GetAccessRoles(bool isAdmin)
        {
            return _database.AccessRoles.GetQueryable().Where(role => role.IsAdministrator == isAdmin).ToList();
        }

        public void SaveAccessRoles(IEnumerable<AccessRole> accessRoles)
        {
            _database.AccessRoles.Clear();
            if (accessRoles.Count() > 0)
                _database.AccessRoles.CreateRange(accessRoles);
        }

        public string GetAdminAccessString(bool isAdmin)
        {
            var roles = _dbContext.AccessRoles
                .Where(acc => acc.IsAdministrator == isAdmin)
                .Select(acc => acc.WindowsRoleName)
                .ToList();
            var result =  (roles.Count > 1) ? roles.Aggregate((a, b) => $"{a}, {b}") : roles.FirstOrDefault();

            if (!isAdmin && string.IsNullOrEmpty(result)) return "Everyone, Все";
            return result;
        }

    }
}
