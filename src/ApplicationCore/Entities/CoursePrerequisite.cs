using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
    public class CoursePrerequisite  : BaseEntity 
    {

        private   CoursePrerequisite()
        {

        }

        public int CourseId { get; set; }

        public int PrerequisiteCourseId { get; set; }

        public Course Course { get; set; }
        public Course PrerequisiteCourse { get; set; }
    }
}
