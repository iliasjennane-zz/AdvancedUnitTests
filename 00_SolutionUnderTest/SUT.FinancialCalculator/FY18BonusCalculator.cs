using SUT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.FinancialCalculator
{
    public class FY18BonusCalculator: IBonusCalculator
    {
        public double GetBonusPercentage(Employee employee)
        {
            double bonusPercentage = 0;
            if (employee.Salary > 100000)
            {
                switch (employee.PerformanceStarLevel)
                {
                    case 1:
                        bonusPercentage = 0;
                        break;
                    case 2:
                        bonusPercentage = 5;
                        break;
                    case 3:
                        bonusPercentage = 20;
                        break;
                    case 4:
                        bonusPercentage = 30;
                        break;
                    case 5:
                        bonusPercentage = 44;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (((System.DateTime.Now - employee.HireDate).TotalDays / 365) > 5)
                {
                    switch (employee.PerformanceStarLevel)
                    {
                        case 1:
                            bonusPercentage = 0;
                            break;
                        case 2:
                            bonusPercentage = 5;
                            break;
                        case 3:
                            bonusPercentage = 22;
                            break;
                        case 4:
                            bonusPercentage = 32;
                            break;
                        case 5:
                            bonusPercentage = 48;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (employee.PerformanceStarLevel)
                    {
                        case 1:
                            bonusPercentage = 0;
                            break;
                        case 2:
                            bonusPercentage = 5;
                            break;
                        case 3:
                            bonusPercentage = 21;
                            break;
                        case 4:
                            bonusPercentage = 31;
                            break;
                        case 5:
                            bonusPercentage = 41;
                            break;
                        default:
                            break;
                    }
                }
            }
            return bonusPercentage;
        }
    }
}
