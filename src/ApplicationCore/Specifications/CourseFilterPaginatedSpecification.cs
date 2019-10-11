using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class CourseFilterPaginatedSpecification : BaseSpecification<Course>
    {
        public CourseFilterPaginatedSpecification(int skip, int take, int? departmentId)
            : base(i => (!departmentId.HasValue || i.DepartmentId == departmentId))
        {
            ApplyPaging(skip, take);
        }
    }
}
