using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class CoursePrerequisitesSpecification : BaseSpecification<CoursePrerequisite>
    {

        
        public CoursePrerequisitesSpecification(int courseId) : base(c => c.CourseId == courseId)
        {
            AddInclude(c => c.PrerequisiteCourse);
            AddInclude(c => c.Course);
        }
    }
}
