using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Document.Service.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public void CreateDocument(string companyId)
        {
            dictionary[companyId] = "Document Sent";
        }

        public string GetDocumentStatus(string companyId)
        {
            if (dictionary.ContainsKey(companyId))
            {
                return dictionary[companyId];
            }
            else
            {
                return "Document Not Sent";
            }
        }
    }
}
