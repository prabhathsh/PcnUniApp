using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class InstructorWithDepartmentSpecification : BaseSpecification<Instructor>
    {
        public InstructorWithDepartmentSpecification(int instructorId) : base(i => i.Id == instructorId)
        {
            AddInclude(i => i.Department);
        }


    }
}
