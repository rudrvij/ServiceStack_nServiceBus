using Autofac;
using Funq;
using NServiceBus;
using Prototype.API.Gateway.Service;
using Prototype.Common.ServiceStack;
using Prototype.Common.ServiceStack.Configuration;
using Prototype.Messages;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Web;

namespace Prototype.API.Gateway.Host
{
    public class AppHost : BaseAppHost
    {
        public AppHost() : base("Gateway Service", typeof(APIGatewayService).Assembly) { }

        public override void Configure(Container container)
        {
            base.Configure(container.IncludeStandardFunctionality());
            // Your Service Configs
            // container.RegisterAutoWiredAs<CustomService, ICustomService>();
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomService>().As<ICustomService>();

            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();
            builder.Register(c => endpoint).As<IMessageSession>().SingleInstance();

            var autoFacCOntainer = builder.Build();
            IContainerAdapter adapter = new AutofacIocAdapter(autoFacCOntainer);
            container.Adapter = adapter;

            var endpointConfiguration = new EndpointConfiguration("APIGateway");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(
                typeof(CreateEnrollment), "EnrollmentService");
            endpointConfiguration.UseContainer<AutofacBuilder>(
               customizations: customizations =>
               {
                   customizations.ExistingLifetimeScope(autoFacCOntainer);
               });

            endpoint = NServiceBus.Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

        }
    }
}
