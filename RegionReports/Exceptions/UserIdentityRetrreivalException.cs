namespace RegionReports.Exceptions
{
    public class UserIdentityRetrreivalException : Exception
    {
        public override string Message { get; }

        public UserIdentityRetrreivalException()
        {
            Message = "Ошибка определения пользователя браузером";
        }
    }
}
