namespace RegionReports.Data.Exceptions
{
    /// <summary>
    /// Исключение, выдаваемое, если в БД не обнаружилоь запрошенной записи пользователя
    /// </summary>
    public class UserNotFoundException : Exception
    {
        public override string Message { get; }

        public UserNotFoundException()
        {
            Message = "В БД не обнаружена запись пользователя";
        }

        public UserNotFoundException(string windowsName)
        {
            Message = $"В БД не обнаружена запись для пользователя {windowsName}";
        }
    }
}