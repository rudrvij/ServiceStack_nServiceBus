using Prototype.Enrollment.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Service
{
    public class EnrollService : IEnrollService
    {
        private IEnrollmentRepository repo;
        public EnrollService(IEnrollmentRepository repo)
        {
            this.repo = repo;
        }
        public void CompleteEnrollment(string companyId)
        {
            repo.CreateEnrollment(companyId);
        }

        public string GetEnrollmentStatus(string companyId)
        {
            return repo.GetEnrollmentStatus(companyId);
        }
    }
}
