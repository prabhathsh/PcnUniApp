using PcnUniApp.ApplicationCore.Entities.StudentEnrollmentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class StudentEnrollementWithSectionByIdSpecification : BaseSpecification<StudentEnrollment>
    {
        public StudentEnrollementWithSectionByIdSpecification(int studentEnrollmentId)
            : base(s => s.Id == studentEnrollmentId)
        {
            AddInclude(s => s.EnrollmentSections);
        }
    }
}
