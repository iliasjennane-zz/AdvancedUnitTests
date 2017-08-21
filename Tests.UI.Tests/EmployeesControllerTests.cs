using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT.UI.Controllers;
using System.Web.Mvc;
using SUT.Entities;
using System.Collections.Generic;
using SUT.DataAccess;
using System.Linq;
using SUT.FinancialCalculator;

namespace Tests.UI.Tests
{
    [TestClass]

    public class EmployeesControllerTests
    {
        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestIndex_ShouldReturnTheIndexViewWithAListOfEmployeesAsAModel()
        {
            //AAA
            //Arrange
            EmployeesController controllerUnderTest = new EmployeesController();
            //Act
            var returnedResult = controllerUnderTest.Index().Result;
            //Assert
            Assert.AreEqual(returnedResult.GetType(), typeof(ViewResult));
            var returnedView = returnedResult as ViewResult;
            Assert.AreEqual(returnedView.Model.GetType(), typeof(List<Employee>));
        }

        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestCreate_ShouldAddAnEmployeeToTheDatabase()
        {
            //AAA
            //Arrange
            EmployeesController controllerUnderTest = new EmployeesController();
            string employeeTestName = "Test Employee " + DateTime.Now.ToLongTimeString();
            var employeeToBeAdded = new Employee { Name = employeeTestName, Salary = 100000, HireDate = DateTime.Now, PerformanceStarLevel = 1 };
            //Act
            var returnedResult = controllerUnderTest.Create(employeeToBeAdded).Result;
            //Assert
            Assert.AreEqual(returnedResult.GetType(), typeof(RedirectToRouteResult));
            var returnedView = returnedResult as RedirectToRouteResult;
            Assert.AreEqual(returnedView.RouteValues["Action"], "Index");

            //Need to verify that the employee has been Added.
            using (db dbContext = new db())
            {
                var employeeInserted = dbContext.Employees.Where(e => e.Name == employeeTestName).FirstOrDefault();
                Assert.IsNotNull(employeeInserted);
            }
        }

        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestDetail_ShouldShowCurrentAndProjectedBonusesForEmployeeMakingMoreThan100K()
        {
            //AAA
            //Arrange
            EmployeesController controllerUnderTest = new EmployeesController();
            string employeeTestName = "Test Employee " + DateTime.Now.ToLongTimeString();
            var employeeToUseForTest = new Employee { Name = employeeTestName, Salary = 200000, HireDate = DateTime.Now, PerformanceStarLevel = 1 };
            using (db dbContext = new db())
            {
                dbContext.Employees.Add(employeeToUseForTest);
                dbContext.SaveChanges();
            }
            var proxy = new BonusProjectorService.BonusProjectorClient();

            var bonusCalculator = new FY18BonusCalculator();

            //Act
            var returnedResult = controllerUnderTest.Details(employeeToUseForTest.Id).Result;
            Assert.AreEqual(returnedResult.GetType(), typeof(ViewResult));
            var returnedView = returnedResult as ViewResult;

            //Assert
            Assert.AreEqual(returnedView.ViewBag.BonusAmount, bonusCalculator.GetBonusPercentage(employeeToUseForTest) * employeeToUseForTest.Salary / 100);
            Assert.AreEqual(returnedView.ViewBag.NextYearProjectBonus, proxy.GetExpectedBonus(employeeToUseForTest.Salary));
        }

    }
}