using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class AllInstructorsWithDepartmentSpecification : BaseSpecification<Instructor>
    {
        public AllInstructorsWithDepartmentSpecification(int id = 0) : base(i => i.Id == id)
        {
            AddInclude(i => i.Department);
        }
    }
}
