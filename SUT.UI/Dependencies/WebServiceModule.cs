using Autofac;
using SUT.UI.BonusProjectorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SUT.UI.Dependencies
{
    public class WebServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            EndpointAddress bonusProjectorServiceEndPoint = new EndpointAddress("http://localhost:1102/BonusProjector.svc");
            ChannelFactory<IBonusProjector> bonusProjectorServiceChannelFactory = new ChannelFactory<IBonusProjector>(httpBinding, bonusProjectorServiceEndPoint);
            var bonusProjector = bonusProjectorServiceChannelFactory.CreateChannel();

            builder.RegisterInstance<IBonusProjector>(bonusProjector);
            base.Load(builder);
        }
    }
}