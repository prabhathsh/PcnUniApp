using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class DepartmentFilterSpecification : BaseSpecification<Department>
    {
        public DepartmentFilterSpecification(string criteria) : base(c => (string.IsNullOrWhiteSpace(criteria) ||  c.Name.Contains(criteria)))
        {

        }

        public DepartmentFilterSpecification(int id) :base(c => c.Id  == id)
        {

        }
    }
}
