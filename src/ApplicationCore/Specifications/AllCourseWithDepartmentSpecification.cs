using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class AllCourseWithDepartmentSpecification : BaseSpecification<Course>
    {

        public AllCourseWithDepartmentSpecification(int courseId = 0) : base(c => c.Id > courseId)
        {
            AddInclude(c => c.Department);
        }
    }
}
