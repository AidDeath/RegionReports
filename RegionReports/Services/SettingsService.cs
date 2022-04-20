using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class SettingsService
    {
        private IConfiguration _configuration;
        private IDbAccessor _database;
        public SettingsService(IConfiguration configuration, IDbAccessor database)
        {
            _configuration = configuration;
            _database = database;
        }

        public string GetFileStoragePath() => _configuration.GetSection("FileStorageSettings").GetValue<string>("FileStoragePath");

        public long GetMaxUploadFileSize() => _configuration.GetSection("FileStorageSettings").GetValue<int>("MaxUploadFileSize");

        public string GetUploadableMimeTypes()
        {
            var a = _database.UploadableFileTypes.GetQueryable();
            return a.ToList().Select(mime => mime.AlowedMimeType).Aggregate((s1, s2) => s1 + ',' + s2);

        }

    }
}
