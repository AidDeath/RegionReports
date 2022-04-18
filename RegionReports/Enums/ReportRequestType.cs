namespace RegionReports.Enums
{
    /// <summary>
    /// Тип запроса информации
    /// </summary>
    public enum ReportRequestType
    {
        /// <summary>
        /// Запрос текстового ответа
        /// </summary>
        TextOnlyReport = 0,
        /// <summary>
        /// Запрос ответа текстом, с возможностью прикрепить файл
        /// </summary>
        TextWithFileReport = 1,
        /// <summary>
        /// Запрос в виде опроса с редактируемыми вариантами ответа
        /// </summary>
        SurveyReport = 2
    }
}
