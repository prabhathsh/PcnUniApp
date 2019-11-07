using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
    public class Student : BaseEntity , IAggregateRoot
    {
       /// <summary>
       /// This property is populated by Identity
       /// </summary>
       /// 
       public enum GenderValues { Male =1 , Female =2 }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderValues Gender { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
