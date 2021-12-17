using System.Linq.Expressions;

namespace RegionReports.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Delete(int id);
        void Delete(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

    }
}
