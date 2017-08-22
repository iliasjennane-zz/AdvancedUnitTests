using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        void Add(TEntity entity);
        IQueryable<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
    }

}
