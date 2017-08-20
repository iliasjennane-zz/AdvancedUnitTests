using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT.DataAccess;

namespace Tests.DataAccess.UnitTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        [TestCategory("Database.UnitTests")]
        public void TestGetAllEmployeesCount_ShouldRetunsTheTotalNumberOfEmployeesInTheDatabase()
        {
            using (db dbContext = new db())
            {
                var totalEmployees = dbContext.Employees.Count();
                Assert.IsTrue(totalEmployees > 0, "The employees table doesn't have any records");

            }
        }
    }
}
