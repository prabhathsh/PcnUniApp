using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
    public class Student : BaseEntity 
    {
       /// <summary>
       /// This property is populated by Identity
       /// </summary>
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
