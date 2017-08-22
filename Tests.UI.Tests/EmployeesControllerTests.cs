using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT.UI.Controllers;
using System.Web.Mvc;
using SUT.Entities;
using System.Collections.Generic;
using SUT.DataAccess;
using System.Linq;
using SUT.FinancialCalculator;
using Moq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SUT.DataAccess.Mocks;
using System.Threading.Tasks;
using Tests.UI.Tests.Mocks;
using SUT.UI.BonusProjectorService;

namespace Tests.UI.Tests
{
    [TestClass]

    public class EmployeesControllerTests
    {
        private Mock<IUnitOfWork<db>> mockUnitOfWork;
        private Mock<IBonusProjector> mockBonusProjector;
        [TestInitialize]
        public void Initialize()
        {
            mockUnitOfWork = MockUnitOfWorkGenerator.GetMockUnitOfWork();
            mockBonusProjector = MockWebServiceClient.GetMockBonusProjectorService();
        }

        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestIndex_ShouldReturnTheIndexViewWithAListOfEmployeesAsAModel()
        {
            //AAA
            //Arrange
            
            EmployeesController controllerUnderTest = new EmployeesController(mockUnitOfWork.Object, null);
            //Act
            var returnedResult = controllerUnderTest.Index().Result;
            //Assert
            Assert.AreEqual(returnedResult.GetType(), typeof(ViewResult));
            var returnedView = returnedResult as ViewResult;
            Assert.AreEqual(returnedView.Model.GetType(), typeof(List<Employee>));
        }

        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestCreate_ShouldAddAnEmployeeToTheDatabaseAndGoBackToIndexView()
        {
            //AAA
            //Arrange
            EmployeesController controllerUnderTest = new EmployeesController(mockUnitOfWork.Object, mockBonusProjector.Object);
            string employeeTestName = "Test Employee " + DateTime.Now.ToLongTimeString();
            var employeeToBeAdded = new Employee { Name = employeeTestName, Salary = 100000, HireDate = DateTime.Now, PerformanceStarLevel = 1 };
            //Act
            var returnedResult = controllerUnderTest.Create(employeeToBeAdded).Result;
            //Assert
            Assert.AreEqual(returnedResult.GetType(), typeof(RedirectToRouteResult));
            var returnedView = returnedResult as RedirectToRouteResult;
            Assert.AreEqual(returnedView.RouteValues["Action"], "Index");
        }

        [TestMethod]
        [TestCategory("UI.Logic.UnitTests")]
        public void TestDetail_ShouldShowCurrentAndProjectedBonusesForEmployeeMakingMoreThan100K()
        {
            //AAA
            //Arrange
            EmployeesController controllerUnderTest = new EmployeesController(mockUnitOfWork.Object, mockBonusProjector.Object);
            string employeeTestName = "Test Employee " + DateTime.Now.ToLongTimeString();
            var employeeToUseForTest = mockUnitOfWork.Object.DbContext.Employees.Where(e => e.Salary >= 100000).FirstOrDefault();
            mockUnitOfWork.Object.DbContext.Employees.Add(employeeToUseForTest);
            var bonusCalculator = new FY18BonusCalculator();

            //Act
            var returnedResult = controllerUnderTest.Details(employeeToUseForTest.Id).Result;
            Assert.AreEqual(returnedResult.GetType(), typeof(ViewResult));
            var returnedView = returnedResult as ViewResult;

            //Assert
            Assert.AreEqual(returnedView.ViewBag.BonusAmount, bonusCalculator.GetBonusPercentage(employeeToUseForTest) * employeeToUseForTest.Salary / 100);
            Assert.AreEqual(returnedView.ViewBag.NextYearProjectBonus, mockBonusProjector.Object.GetExpectedBonus(employeeToUseForTest.Salary));
        }

    }
}