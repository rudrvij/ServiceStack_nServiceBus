using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Contracts
{
    [Route("/enrollment/{CompanyId}", "GET")]
    public class EnrollmentStatusRequest : IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
