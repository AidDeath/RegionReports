using RegionReports.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Interfaces
{
    public interface IReportUserApprovalClaimRepository : IRepository<ReportUserApprovalClaim>
    {
        /// <summary>
        /// Получить последнюю неутвержденную заявку для пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        ReportUserApprovalClaim? GetLastClaimForUser(int userId);

        /// <summary>
        /// Получить все заявки на изменение данных пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        IEnumerable<ReportUserApprovalClaim> GetAllClaimsForUser(int userId);
        
    }
}
