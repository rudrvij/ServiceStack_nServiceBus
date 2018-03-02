using Prototype.Common.ServiceStack;
using Prototype.Enrollment.Contracts;
using Prototype.Enrollment.Service.Repository;
using NServiceBus;
using Prototype.Messages;

namespace Prototype.Enrollment.Service
{
    public class EnrollmentService : BaseService
    {
        public IEnrollService svc { get; set; }
        
        public string Get(EnrollmentStatusRequest request)
        {
            return svc.GetEnrollmentStatus(request.CompanyId);
        }

        public string Post(EnrollmentRequest request)
        {
            svc.CompleteEnrollment(request.CompanyId);

            var enrollmentDoneEvent = new EnrollmentDone() { CompanyId = request.CompanyId };
            ServiceBusEndpoint.Publish(enrollmentDoneEvent).GetAwaiter().GetResult();

            return "Created Enrollment Command";
        }

    }
}
