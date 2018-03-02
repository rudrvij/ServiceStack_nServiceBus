using NServiceBus;
using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Document.Service
{
    public class EnrollmentDoneHandler : IHandleMessages<EnrollmentDone>
    {
        public IDocService svc { get; set; }

        public Task Handle(EnrollmentDone message, IMessageHandlerContext context)
        {
            svc.AddDocument(message.CompanyId);
            return Task.CompletedTask;
        }
    }
}
