using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Contracts
{
    [Route("/enrollment", "POST")]
    public class CreateEnrollmentRequest: IPost, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
