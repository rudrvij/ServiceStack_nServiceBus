using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Contracts
{
    [Route("/enrollment", "POST")]
    public class EnrollmentRequest: IPost, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
