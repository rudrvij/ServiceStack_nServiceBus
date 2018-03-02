using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Service.Repository
{
    public interface IEnrollmentRepository
    {
        void CreateEnrollment(string companyId);
        string GetEnrollmentStatus(string companyId);
    }
}
