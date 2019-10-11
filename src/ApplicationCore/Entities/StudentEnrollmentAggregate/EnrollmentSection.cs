using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.StudentEnrollmentAggregate
{
    public class EnrollmentSection : BaseEntity
    {
        public int CourseId { get; private set; }
        public int SemesterCourseId { get; private set; }
        public int SectionId { get; private set; }
        public int NumberOfCredits { get; private set; }
        public string Grade { get; set; }
        public double? Marks { get; set; }
        public bool IsPass { get; set; }

        public DateTime EnrolleedDate { get; private set; }

        private EnrollmentSection()
        {

        }

        public EnrollmentSection(int courseId, int semesterCourseId,
            int sectionId, int numberOfCredits)
        {
            CourseId = courseId;
            SemesterCourseId = semesterCourseId;
            SectionId = sectionId;
            NumberOfCredits = numberOfCredits;
            EnrolleedDate = DateTime.Now;


        }
    }
}
