using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Service.Repository
{
    public interface IDocumentRepository
    {
        void CreateDocument(string companyId);

        string GetDocumentStatus(string companyId);
    }
}
