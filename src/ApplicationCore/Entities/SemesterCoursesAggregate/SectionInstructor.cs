using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate
{
    public class SectionInstructor : BaseEntity
    {
        private SectionInstructor() { }
        public int InstructorId { get; private set; }

        public SectionInstructor(int instructorId)
        {
            InstructorId = instructorId;

        }
    }
}
