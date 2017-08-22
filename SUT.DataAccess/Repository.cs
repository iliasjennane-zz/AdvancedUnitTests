using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;

        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public Repository()
        {
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }

}
