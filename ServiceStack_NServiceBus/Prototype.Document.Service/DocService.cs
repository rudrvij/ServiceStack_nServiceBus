using Prototype.Document.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Service
{
    public class DocService : IDocService
    {
        private IDocumentRepository repo;

        public DocService(IDocumentRepository repo)
        {
            this.repo = repo;
        }
        public void AddDocument(string companyId)
        {
            repo.CreateDocument(companyId);
        }

        public string GetDocumentStatus(string companyId)
        {
            return repo.GetDocumentStatus(companyId);
        }
    }
}
