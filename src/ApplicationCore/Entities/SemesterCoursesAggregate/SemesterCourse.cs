using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate
{
    public class SemesterCourse : BaseEntity, IAggregateRoot
    {
        private SemesterCourse() { }
        public SemesterOfferedCourse SemesterOfferedCourse { get; private set; }

        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public int NumberOfCredits { get; set; }

        //private readonly List<CoursePrerequisite> _coursePrerequisites= new List<CoursePrerequisite>();

        // public IReadOnlyCollection<CoursePrerequisite> CoursePrerequisites => _coursePrerequisites.AsReadOnly();

        private readonly List<CourseSection> _courseSections = new List<CourseSection>();
        public IReadOnlyCollection<CourseSection> CourseSections => _courseSections.AsReadOnly();

        public SemesterCourse(SemesterOfferedCourse semesterOfferedCourse,
                    // List<CoursePrerequisite> coursePrerequisites,
                    List<CourseSection> courseSections, int numberOfCredits)
        {
            SemesterOfferedCourse = semesterOfferedCourse;
            // _coursePrerequisites = coursePrerequisites;
            _courseSections = courseSections;
            NumberOfCredits = numberOfCredits;
        }
    }
}
