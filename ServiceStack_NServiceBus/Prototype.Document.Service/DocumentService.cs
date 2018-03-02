using Prototype.Common.ServiceStack;
using Prototype.Document.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Service
{
    public class DocumentService: BaseService
    {
        public IDocService svc { get; set; }

        public string Get(DocumentStatusRequest request)
        {
            return svc.GetDocumentStatus(request.CompanyId);
        }
    }
}
