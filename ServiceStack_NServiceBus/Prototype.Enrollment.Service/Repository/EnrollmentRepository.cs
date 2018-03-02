using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Service.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public void CreateEnrollment(string companyId)
        {
            dictionary.Add(companyId, "Done");
        }

        public string GetEnrollmentStatus(string companyId)
        {
            if (dictionary.ContainsKey(companyId))
            {
                return dictionary[companyId];
            }
            else
            {
                return "Not Started";
            }
        }
    }
}
