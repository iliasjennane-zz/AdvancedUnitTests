using Autofac;
using Autofac.Core;
using SUT.DataAccess;

namespace SUT.UI.Dependencies
{
    internal class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerRequest();
            base.Load(builder);
        }
    }
}