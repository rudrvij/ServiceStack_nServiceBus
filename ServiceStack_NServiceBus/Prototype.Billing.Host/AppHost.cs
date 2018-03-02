using Autofac;
using Funq;
using NServiceBus;
using Prototype.Billing.Service;
using Prototype.Billing.Service.Repository;
using Prototype.Common.ServiceStack;
using ServiceStack;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Billing.Host
{
    public class AppHost : BaseAppHost
    {
        public AppHost() : base("Billing Service", typeof(BillingService).Assembly) { }

        public override void Configure(Container container)
        {
            base.Configure(container.IncludeStandardFunctionality());
            var builder = new ContainerBuilder();
            builder.RegisterType<BillingRepository>().As<IBillingRepository>();
            builder.RegisterType<BillService>().As<IBillService>();

            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();

            builder.Register(c => endpoint).As<IMessageSession>().SingleInstance();

            var autoFacCOntainer = builder.Build();
            IContainerAdapter adapter = new AutofacIocAdapter(autoFacCOntainer);
            container.Adapter = adapter;

            var endpointConfiguration = new EndpointConfiguration("BillingService");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UseContainer<AutofacBuilder>(
               customizations: customizations =>
               {
                   customizations.ExistingLifetimeScope(autoFacCOntainer);
               });

            endpoint = NServiceBus.Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
        }
    }
}

