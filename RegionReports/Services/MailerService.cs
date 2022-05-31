using RegionReports.Data;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class MailerService
    {
        private readonly RegionReportsContext _dbContext;
        private readonly IDbAccessor _database;

        public MailerService(RegionReportsContext dbContext, IDbAccessor database)
        {
            _dbContext = dbContext;
            _database = database;
        }

        public IEnumerable<MailerProfile>? GetAllMailerProfiles()
        {
            return _database.MailerProfiles.GetQueryable().ToList();
        }
    
        public void UpdateMailerProfile(MailerProfile mailerProfile)
        {
            _database.MailerProfiles.Update(mailerProfile);
        }
    }
}
