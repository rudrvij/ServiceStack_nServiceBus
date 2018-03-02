using NServiceBus;
using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service
{
    public class CreateEnrollmentHandler : IHandleMessages<CreateEnrollment>
    {
        private IEnrollService svc;
        public CreateEnrollmentHandler(IEnrollService svc)
        {
            this.svc = svc;

        }
        public Task Handle(CreateEnrollment message, IMessageHandlerContext context)
        {
            // DO your business logic
            svc.CompleteEnrollment(message.CompanyId);

            //Now Publish
            var enrollmentDoneEvent = new EnrollmentDone() { CompanyId = message.CompanyId };
            return context.Publish(enrollmentDoneEvent);

        }
    }
}
