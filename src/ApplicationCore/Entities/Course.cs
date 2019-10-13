using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
    public class Course : BaseEntity
    {

        
        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        //Mapping is not working properly for hierarchy relationship
        //  private readonly List<CoursePrerequisite> _coursePrerequisite = new List<CoursePrerequisite>();
        // public IReadOnlyCollection<CoursePrerequisite> CoursePrerequisites => _coursePrerequisite.AsReadOnly();



        // private readonly List<CoursePrerequisite> _currentCourse = new List<CoursePrerequisite>();
        // public IReadOnlyCollection<CoursePrerequisite> CurrentCourse = new List<CoursePrerequisite>();
        public  ICollection<CoursePrerequisite> PrerequisiteCourse { get; set; }
        public  ICollection<CoursePrerequisite> CurrentCourse { get; set; }

    }
}
