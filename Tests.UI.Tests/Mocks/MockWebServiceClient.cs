using Moq;
using SUT.UI.BonusProjectorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UI.Tests.Mocks
{
    public class MockWebServiceClient
    {
        public static Mock<IBonusProjector> GetMockBonusProjectorService()
        {
            var mockBonusProjector = new Mock<IBonusProjector>();
            mockBonusProjector.Setup(b => b.GetExpectedBonus(It.IsAny<double>())).Returns(25000);
            return mockBonusProjector;
        }
    }
}
