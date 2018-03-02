using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Service
{
    public class CustomService : ICustomService
    {
        public string GetData(string companyId)
        {
            return @"data from {companyId}";
        }
    }
}
