using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
   public  class Department  : BaseEntity 
    {
        public Department()
        {

        }

        public Department(string name, decimal budget, DateTime startDate)
        {
            Name = name;
            Budget = budget;
            StartDate = startDate;
        }
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        private readonly List<Course> _courses = new List<Course>();

        public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();

        public readonly List<Instructor> _instructors = new List<Instructor>();

        public IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();

        private readonly List<Student> _students = new List<Student>();
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
    }
}
