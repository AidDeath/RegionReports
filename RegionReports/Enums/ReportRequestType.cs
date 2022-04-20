namespace RegionReports.Enums
{
    /// <summary>
    /// Тип запроса информации
    /// </summary>
    public enum ReportRequestType
    {
        /// <summary>
        /// Запрос ответа текстом, с возможностью прикрепить файл
        /// </summary>
        TextOnlyReport = 1,

        /// <summary>
        /// Запрос в виде опроса с редактируемыми вариантами ответа
        /// </summary>
        SurveyReport = 2
    }
}
