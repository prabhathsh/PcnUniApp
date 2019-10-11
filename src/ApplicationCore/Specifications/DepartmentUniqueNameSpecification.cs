using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class DepartmentUniqueNameSpecification : BaseSpecification<Department>
    {
        public DepartmentUniqueNameSpecification(string name) : base(c => c.Name == name)
        {

        }

        public DepartmentUniqueNameSpecification(string name, int id) : base(d => d.Name == name && d.Id != id)
        {

        }
    }
}
