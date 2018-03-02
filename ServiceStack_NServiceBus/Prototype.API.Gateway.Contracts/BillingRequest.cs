using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Contracts
{
    [Route("/billing/{CompanyId}", "GET")]
    public class BillingRequest: IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
   
}
