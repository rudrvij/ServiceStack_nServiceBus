using Prototype.API.Gateway.Contracts;
using Prototype.Billing.Contracts;
using Prototype.Common.ServiceStack;
using Prototype.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using Prototype.Enrollment.Contracts;
using Prototype.Document.Contracts;

namespace Prototype.API.Gateway.Service
{
    public class APIGatewayService : BaseService
    {
        public ICustomService svc { get; set; }

        public string Get(BillingRequest request)
        {
            return Gateway.Send<string>(new BillingStatusRequest() { CompanyId =request.CompanyId } );           
        }

        public string Get(DocumentRequest request)
        {
            return Gateway.Send<string>(new DocumentStatusRequest() { CompanyId = request.CompanyId } );
        }

        public string Get(Contracts.EnrollmentRequest request)
        {
            return base.Gateway.Send<string>(new Enrollment.Contracts.EnrollmentStatusRequest() { CompanyId = request.CompanyId });            
        }

        public string Post(CreateEnrollmentRequest request)
        {
            var message = new CreateEnrollment() { CompanyId = request.CompanyId };
            ServiceBusEndpoint.Send(message).GetAwaiter().GetResult();

            return "Done";
        }

    }
}
