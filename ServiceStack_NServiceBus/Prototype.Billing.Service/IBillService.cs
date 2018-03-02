using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Billing.Service
{
    public interface IBillService
    {
        void AddBilling(string companyId);
        string GetBillingStatus(string companyId);
    }
}
