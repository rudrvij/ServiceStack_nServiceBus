using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Service
{
    public interface ICustomService
    {
        string GetData(string companyId);
    }
}
