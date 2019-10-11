using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class CourseWithDepartmentSpecification : BaseSpecification<Course>
    {
        public CourseWithDepartmentSpecification(int courseId) : base(c => c.Id == courseId)
        {
            AddInclude(c => c.Department);
        }

        //public CourseWithDepartmentSpecification(int deId) :base(c => c.Id > 0)
        //{

        //}
    }
}
