using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext, new()
    {
        TDbContext DbContext { get; }
        System.Threading.Tasks.Task<int> SaveAsync();
    }


}
