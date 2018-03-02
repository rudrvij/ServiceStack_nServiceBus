using Prototype.Common.ServiceStack;
using Prototype.Enrollment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funq;
using Autofac;
using Prototype.Enrollment.Service.Repository;
using NServiceBus;
using ServiceStack.Configuration;

namespace Prototype.Enrollment.Host
{
    public class AppHost : BaseAppHost    
    {
        public AppHost() : base("Enrollment Service", typeof(EnrollmentService).Assembly) { }

        public override void Configure(Container container)
        {
            base.Configure(container.IncludeStandardFunctionality());
            // Your Service Configs
            // container.RegisterAutoWiredAs<CustomService, ICustomService>();
            var builder = new ContainerBuilder();
            builder.RegisterType<EnrollmentRepository>().As<IEnrollmentRepository>();
            builder.RegisterType<EnrollService>().As<IEnrollService>();

            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();
            builder.Register(c => endpoint).As<IMessageSession>().SingleInstance();

            var autoFacCOntainer = builder.Build();
            IContainerAdapter adapter = new AutofacIocAdapter(autoFacCOntainer);
            container.Adapter = adapter;

            var endpointConfiguration = new EndpointConfiguration("EnrollmentService");
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
