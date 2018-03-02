using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Billing.Contracts
{
    [Route("/billing/{CompanyId}", "GET")]
    public class BillingStatusRequest: IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
