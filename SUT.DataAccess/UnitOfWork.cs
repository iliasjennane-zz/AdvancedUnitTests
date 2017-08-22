using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext, new()
    {

        private readonly TDbContext _dbContext;
        public TDbContext DbContext { get { return _dbContext; } }
        public UnitOfWork()
        {
            _dbContext = new TDbContext();
        }

        public UnitOfWork(TDbContext DbContext)
        {
            _dbContext = DbContext;
        }


        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }

}
