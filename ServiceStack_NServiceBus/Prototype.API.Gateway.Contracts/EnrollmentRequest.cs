using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Contracts
{
    [Route("/enrollment/{CompanyId}", "GET")]
    public class EnrollmentRequest: IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
