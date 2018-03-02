using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Billing.Service.Repository
{
    public interface IBillingRepository
    {
        void AddBilling(string companyId);
        string GetBillingStatus(string companyId);
    }
}
