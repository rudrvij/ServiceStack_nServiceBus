using Autofac;
using Funq;
using Prototype.Common.ServiceStack.Configuration;
using ServiceStack.Configuration;
using ServiceStack.Web;
using System;
using System.Collections.Generic;

using System.Text;

namespace Prototype.Common.ServiceStack
{
    public static class ContainerExtensions
    {
        public static Container IncludeStandardFunctionality(this Container container)
        {
            return container.WithStandardGatewayFactory();
                            
        }
        public static Container WithStandardGatewayFactory(this Container container)
        {
            var requestTypes = ServiceStackConfiguration.RequestTypes;
            container.Register<IServiceGatewayFactory>(c => new ServiceStackGatewayFactory(requestTypes));

            return container;
        }
        public static Container WithAutofac(this Container container)
        {
            var builder = new ContainerBuilder();
            IContainerAdapter adapter = new AutofacIocAdapter(builder.Build());
            container.Adapter = adapter;
            return container;
        }
    }
}
