using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT.Entities;
using SUT.FinancialCalculator;

namespace Tests.FinancialCalculator.UnitTests
{
    [TestClass]
    public class FY18BonusCalculatorTests
    {
        [TestMethod]
        [TestCategory("BusinessLogic.UnitTests")]
        public void TestGetBonusPercentage_ValidatesCorrectBonusPercentageForEmployeesMakingMoreThan100KAndPerformanceLevel1()
        {
            //AAA

            //Arrange
            var employeeUnderTest = new Employee { Id = 1, Name = "Joe Doe", Salary = 110000, HireDate = DateTime.Parse("01/01/2015"), PerformanceStarLevel = 1 };
            var classUnderTest = new FY18BonusCalculator();
            decimal expectedBonusPercentage = 0;
            //Act
            var returnedBonusPercentage = classUnderTest.GetBonusPercentage(employeeUnderTest);
            //Assert
            Assert.AreEqual(expectedBonusPercentage, returnedBonusPercentage, $"Wrong percentage value returned: {returnedBonusPercentage} , while expected is: {expectedBonusPercentage}");
        }

        [TestMethod]
        [TestCategory("BusinessLogic.UnitTests")]
        public void TestGetBonusPercentage_ValidatesCorrectBonusPercentageForEmployeesMakingMoreThan100KAndPerformanceLevel2()
        {
            //AAA

            //Arrange
            var employeeUnderTest = new Employee { Id = 1, Name = "Joe Doe", Salary = 110000, HireDate = DateTime.Parse("01/01/2015"), PerformanceStarLevel = 2 };
            var classUnderTest = new FY18BonusCalculator();
            decimal expectedBonusPercentage = 5;
            //Act
            var returnedBonusPercentage = classUnderTest.GetBonusPercentage(employeeUnderTest);
            //Assert
            Assert.AreEqual(expectedBonusPercentage, returnedBonusPercentage, $"Wrong percentage value returned: {returnedBonusPercentage} , while expected is: {expectedBonusPercentage}");
        }

        [TestMethod]
        [TestCategory("BusinessLogic.UnitTests")]
        public void TestGetBonusPercentage_ValidatesCorrectBonusPercentageForEmployeesMakingMoreThan100KAndPerformanceLevel3()
        {
            //AAA

            //Arrange
            var employeeUnderTest = new Employee { Id = 1, Name = "Joe Doe", Salary = 110000, HireDate = DateTime.Parse("01/01/2015"), PerformanceStarLevel = 3  };
            var classUnderTest = new FY18BonusCalculator();
            decimal expectedBonusPercentage = 20;
            //Act
            var returnedBonusPercentage = classUnderTest.GetBonusPercentage(employeeUnderTest);
            //Assert
            Assert.AreEqual(expectedBonusPercentage, returnedBonusPercentage, $"Wrong percentage value returned: {returnedBonusPercentage} , while expected is: {expectedBonusPercentage}");
        }

        [TestMethod]
        [TestCategory("BusinessLogic.UnitTests")]
        public void TestGetBonusPercentage_ValidatesCorrectBonusPercentageForEmployeesMakingMoreThan100KAndPerformanceLevel4()
        {
            //AAA

            //Arrange
            var employeeUnderTest = new Employee { Id = 1, Name = "Joe Doe", Salary = 110000, HireDate = DateTime.Parse("01/01/2015"), PerformanceStarLevel = 4 };
            var classUnderTest = new FY18BonusCalculator();
            decimal expectedBonusPercentage = 30;
            //Act
            var returnedBonusPercentage = classUnderTest.GetBonusPercentage(employeeUnderTest);
            //Assert
            Assert.AreEqual(expectedBonusPercentage, returnedBonusPercentage, $"Wrong percentage value returned: {returnedBonusPercentage} , while expected is: {expectedBonusPercentage}");
        }

        [TestMethod]
        [TestCategory("BusinessLogic.UnitTests")]
        public void TestGetBonusPercentage_ValidatesCorrectBonusPercentageForEmployeesMakingMoreThan100KAndPerformanceLevel5()
        {
            //AAA

            //Arrange
            var employeeUnderTest = new Employee { Id = 1, Name = "Joe Doe", Salary = 110000, HireDate = DateTime.Parse("01/01/2015"), PerformanceStarLevel = 5 };
            var classUnderTest = new FY18BonusCalculator();
            decimal expectedBonusPercentage = 44;
            //Act
            var returnedBonusPercentage = classUnderTest.GetBonusPercentage(employeeUnderTest);
            //Assert
            Assert.AreEqual(expectedBonusPercentage, returnedBonusPercentage, $"Wrong percentage value returned: {returnedBonusPercentage} , while expected is: {expectedBonusPercentage}");
        }
    }
}
