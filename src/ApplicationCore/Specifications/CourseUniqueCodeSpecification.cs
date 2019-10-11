using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
    public class CourseUniqueCodeSpecification : BaseSpecification<Course>
    {
        public CourseUniqueCodeSpecification(string code)
            : base(c => (c.Code == code))
        {

        }
        public CourseUniqueCodeSpecification(int id, string code)
            : base(c => ((c.Code == code) && (c.Id != id)))
        {

        }
    }
}
