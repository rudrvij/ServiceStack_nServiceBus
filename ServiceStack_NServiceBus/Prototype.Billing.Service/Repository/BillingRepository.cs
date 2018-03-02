using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Billing.Service.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public void AddBilling(string companyId)
        {
            dictionary.Add(companyId, "Billed");
        }

        public string GetBillingStatus(string companyId)
        {
            if (dictionary.ContainsKey(companyId))
            {
                return dictionary[companyId];
            }
            else
            {
                return "Not Billed";
            }
        }
    }
}
