using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SUT.SoapServices
{
    [ServiceContract]
    public interface IBonusProjector
    {
        [OperationContract]
        double GetExpectedBonus(double employeeCurrentSalary);
    }
}
