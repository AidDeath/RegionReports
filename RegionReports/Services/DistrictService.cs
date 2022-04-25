using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class DistrictService
    {
        private readonly IDbAccessor _database;
        public DistrictService(IDbAccessor database)
        {
            _database = database;
        }

        public IEnumerable<District> GetFilteredDistrictsList(string filterString)
        {
            var resultSet = _database.Districts.GetQueryable();
            resultSet = resultSet.Where(district => district.ReportUserId == null);
            //Применяю фильтр
            resultSet = resultSet.Where(d => d.DistrictName.ToLower().Contains(filterString.ToLower()));
            return resultSet.AsEnumerable();
        }

        public IEnumerable<District> GetFullDistrictsList()
        {
            return _database.Districts.GetQueryable().AsEnumerable();
        }

        public async Task<IEnumerable<District>> GetDistrictsWithUsersAsync()
        {
            return await _database.Districts.GetQueryable().Where(d => d.ReportUserId != null).Include(d => d.ReportUser).ToListAsync();
        }

    }
}
