using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT.DataAccess;

namespace Tests.DataAccess.UnitTests
{
    [TestClass]
    public class DbTests
    {
        [TestMethod]
        [TestCategory("Database.UnitTests")]
        public void TestContextCreation_MakesSureDatabaseConnectivityIsSuccessful()
        {
            using (db dbContext = new db())
            {
                Assert.IsTrue(dbContext.Database.Exists(), $"Cannot connect to the database using the following connection string {dbContext.Database.Connection.ConnectionString}.");
            }
        }
    }
}
