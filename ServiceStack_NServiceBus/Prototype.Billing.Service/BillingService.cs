using Prototype.Billing.Contracts;
using Prototype.Billing.Service.Repository;
using Prototype.Common.ServiceStack;

namespace Prototype.Billing.Service
{
    public class BillingService: BaseService
    {
        public IBillService svc { get; set; }
        public string Get(BillingStatusRequest request)
        {
            return svc.GetBillingStatus(request.CompanyId);
        }
    }
}
