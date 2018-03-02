using Prototype.Billing.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Billing.Service
{
    public class BillService : IBillService
    {
        private IBillingRepository repo;

        public BillService(IBillingRepository repo)
        {
            this.repo = repo;
        }

       
        public void AddBilling(string companyId)
        {
            repo.AddBilling(companyId);
        }

        public string GetBillingStatus(string companyId)
        {
            return repo.GetBillingStatus(companyId);
        }
    }
}
