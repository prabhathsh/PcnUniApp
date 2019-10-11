using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate
{
    public class SemesterOfferedCourse // ValueObject
    {

        private SemesterOfferedCourse() { }

        public SemesterOfferedCourse(int semesterYearId,
           int courseId, int departmentId)
        {
            SemesterYearId = semesterYearId;
            CourseId = courseId;
            DeprtmentId = departmentId;

        }
        //  public int Semester { get;private  set; }

        // public int Year { get;private  set; }

        public int SemesterYearId { get; private set; }

        public int CourseId { get; private set; }

        public int DeprtmentId { get; private set; }
    }
}
