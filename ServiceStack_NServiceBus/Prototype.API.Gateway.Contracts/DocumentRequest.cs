using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.API.Gateway.Contracts
{
    [Route("/document/{CompanyId}", "GET")]
    public class DocumentRequest : IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
