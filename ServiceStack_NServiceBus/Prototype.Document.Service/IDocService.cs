using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Service
{
    public interface IDocService
    {
        void AddDocument(string companyId);

        string GetDocumentStatus(string companyId);
    }
}
