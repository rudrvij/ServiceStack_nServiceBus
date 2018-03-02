using NServiceBus;
using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Billing.Service
{
    public class EnrollmentDoneHandler : IHandleMessages<EnrollmentDone>
    {
        public IBillService svc { get; set; }

        public Task Handle(EnrollmentDone message, IMessageHandlerContext context)
        {
            svc.AddBilling(message.CompanyId);
            return Task.CompletedTask;
        }
    }
}
