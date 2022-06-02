namespace RegionReports.Data.Entities
{
    //TODO: Реализовать настройки!
    public class Settings
    {
    }

    /// <summary>
    /// Файлы, которые разрешено загружать в запрос отчета и в ответы
    /// </summary>
    internal class FileSettings
    {
        public long MaxFileSizeToUpload { get; set; } = 5 * 1024 * 1024;

        public string FileStoragePath { get; set; }
    }

    internal class MailSettings
    {
    }

    internal class AccessSettings
    {
    }

    /// <summary>
    /// Таблица с MIME типами файлов, которые можно загрузить на сервер
    /// </summary>
    public class UploadableFileType
    {
        public int Id { get; set; }
        public string AlowedMimeType { get; set; } = string.Empty;
    }
}