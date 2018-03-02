using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Contracts
{
    [Route("/document/{CompanyId}", "GET")]
    public class DocumentStatusRequest: IGet, IReturn<string>
    {
        public string CompanyId { get; set; }
    }
}
