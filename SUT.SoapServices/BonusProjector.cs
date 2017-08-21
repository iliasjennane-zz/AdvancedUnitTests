using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace SUT.SoapServices
{
  
    public class BonusProjector : IBonusProjector
    {
        public double GetExpectedBonus(double employeeCurrentSalary)
        {
            double projectedMaxBonus;
            if (employeeCurrentSalary >100000)
            {
                projectedMaxBonus = 0.5 * employeeCurrentSalary;
            }
            else
            {
                projectedMaxBonus = 0.45 * employeeCurrentSalary;
            }
            return projectedMaxBonus;
        }
    }
}