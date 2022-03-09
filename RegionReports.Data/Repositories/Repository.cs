using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RegionReportsContext Context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(RegionReportsContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public virtual TEntity? Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual void CreateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            Context.SaveChanges();
        }

        public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await Context.SaveChangesAsync();
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null) return;
            _dbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null) return;
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            Context.SaveChanges();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).CurrentValues.SetValues(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).CurrentValues.SetValues(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Entry(entity).CurrentValues.SetValues(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Entry(entity).CurrentValues.SetValues(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            await Context.SaveChangesAsync();
        }
    }
}
