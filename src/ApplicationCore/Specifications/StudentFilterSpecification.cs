using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class StudentFilterSpecification : BaseSpecification<Student>
    {
        public StudentFilterSpecification(string searchFilter, int? departmentId) 
                        : base(i =>((string.IsNullOrEmpty(searchFilter) || i.LastName.Contains(searchFilter) || i.FirstName.Contains(searchFilter)) 
                            && (!departmentId.HasValue  || i.DepartmentId  == departmentId)))
        {
        }
    }
}
