using Moq;
using SUT.DataAccess;
using SUT.DataAccess.Mocks;
using SUT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UI.Tests.Mocks
{
    public static class MockUnitOfWorkGenerator
    {
        public static Mock<IUnitOfWork<db>> GetMockUnitOfWork()
        {
            var employees = new List<Employee>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var employee = new Employee { Id = i + 1, Name = $"Some Name {i}", HireDate = DateTime.Now.AddMonths(-1), Salary = 100000 + (i * 10), PerformanceStarLevel = random.Next(1, 5) };
                employees.Add(employee);
            }
            var data = employees.AsQueryable();

            var mockDbSet = new Mock<DbSet<Employee>>();
            mockDbSet.As<IDbAsyncEnumerable<Employee>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Employee>(data.GetEnumerator()));
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Employee>(data.Provider));
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockDbSet.Setup(t => t.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(employees.FirstOrDefault()));

            var mockDbContext = new Mock<db>();
            mockDbContext.Setup(c => c.Employees).Returns(mockDbSet.Object);
            mockDbContext.Setup(c => c.Set<Employee>()).Returns(mockDbSet.Object);
          



            var uowMock = new Mock<IUnitOfWork<db>>();
            uowMock.Setup(u => u.SaveAsync()).Returns(Task.FromResult(1));
            uowMock.Setup(uow => uow.DbContext).Returns(mockDbContext.Object);

            return uowMock;
        }
    }
}
