using PcnUniApp.ApplicationCore.Entities.StudentEnrollmentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class StudentEnrollementWithSectionSpecification : BaseSpecification<StudentEnrollment>
    {
        public StudentEnrollementWithSectionSpecification(int studentId, int SemesterYearId)
            : base(s => s.StudentId == studentId && s.SemesterYearId == SemesterYearId)
        {
            AddInclude(s => s.EnrollmentSections);
        }

        public StudentEnrollementWithSectionSpecification(int studentId)
            : base(s => s.StudentId == studentId)
        {
            AddInclude(s => s.EnrollmentSections);
        }
    }
}
