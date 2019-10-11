using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class CourseFilterSpecification : BaseSpecification<Course>
    {
        public CourseFilterSpecification(int? departmentId)
            : base(i => (!departmentId.HasValue || i.DepartmentId == departmentId))
        {

        }
    }
}
