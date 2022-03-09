using System.Linq.Expressions;

namespace RegionReports.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить сущность без воженных объектов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity? Get(int id);

        /// <summary>
        /// Получить Queryable для последующего формирования запроса
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable();

        /// <summary>
        /// Найти сущность по выражению
        /// </summary>
        /// <param name="predicate">выражение, в результатом bool</param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Записать сущность в БД
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        /// <summary>
        /// ЗАписать сущность асинхронно
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// ЗАписать в БД набор сущностей
        /// </summary>
        /// <param name="entities"></param>
        void CreateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Создать в БД набор сущностей асинхронно
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удвлить сущность
        /// </summary>
        /// <param name="id"> Идентификатор удаляемой сущности</param>
        void Delete(int id);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">объект с сущностью</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Удалить сущность асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// удалить асинхронно
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Удалить набор сущностей
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<TEntity> entities);
        
        /// <summary>
        /// Удалить набор сущностей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        
        /// <summary>
        /// Обновить сущность асинхронно
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Обновить набор сущностей
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновсить набор сущностей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

    }
}
