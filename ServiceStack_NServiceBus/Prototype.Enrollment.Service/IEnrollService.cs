using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Enrollment.Service
{
    public interface IEnrollService
    {
        void CompleteEnrollment(string companyId);
        string GetEnrollmentStatus(string companyId);
    }
}
