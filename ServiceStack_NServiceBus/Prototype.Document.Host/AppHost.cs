using Prototype.Common.ServiceStack;
using Prototype.Document.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funq;
using Autofac;
using NServiceBus;
using ServiceStack.Configuration;
using Prototype.Document.Service.Repository;

namespace Prototype.Document.Host
{
    public class AppHost : BaseAppHost
    {
        public AppHost() : base("Document Service", typeof(DocumentService).Assembly) { }

        public override void Configure(Container container)
        {
            base.Configure(container.IncludeStandardFunctionality());

            //Using Autofac with NServiceBus 
            var builder = new ContainerBuilder();

            builder.RegisterType<DocumentRepository>().As<IDocumentRepository>();
            builder.RegisterType<DocService>().As<IDocService>();

            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();

            builder.Register(c => endpoint).As<IMessageSession>().SingleInstance();

            // Including Autofac for ServiceStack
            var autoFacCOntainer = builder.Build();
            IContainerAdapter adapter = new AutofacIocAdapter(autoFacCOntainer);
            container.Adapter = adapter;

            var endpointConfiguration = new EndpointConfiguration("DocumentService");
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
