using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate
{
    public class CourseSection : BaseEntity
    {
        private CourseSection()
        {

        }

        public CourseSection(int capacity, List<SectionInstructor> sectionInstructor,
            List<SectionLocation> sectionLocation)
        {
            Capacity = AvailableSeats = capacity;
            _sectionInstructors = sectionInstructor;
            _sectionLocations = sectionLocation;
        }
        public int Capacity { get; private set; }


        public int AvailableSeats { get; private set; }

        private readonly List<SectionLocation> _sectionLocations = new List<SectionLocation>();
        public IReadOnlyCollection<SectionLocation> SectionLocations => _sectionLocations.AsReadOnly();


        private readonly List<SectionInstructor> _sectionInstructors = new List<SectionInstructor>();
        public IReadOnlyCollection<SectionInstructor> SectionInstructors => _sectionInstructors.AsReadOnly();




    }
}
