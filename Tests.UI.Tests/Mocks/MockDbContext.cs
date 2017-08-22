using Moq;
using SUT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess.Mocks
{
    public class MockDbContext
    {
        private DbContext dbContext;
        public DbContext DbContext { get { return dbContext;} }
        public MockDbContext()
        {
            dbContext = new Mock<db>().Object;
        }

    }
    public class MockDbSet<TEntity> where TEntity : class 
    {
        private DbSet<TEntity> mockObject;
        public DbSet<TEntity> DbSet { get { return mockObject; } }

        public MockDbSet()
        {
            mockObject = new Mock<DbSet<TEntity>>().Object;

        }
    }
}
