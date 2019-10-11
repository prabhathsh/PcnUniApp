using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities
{
    public class SemesterYear : BaseEntity 
    {
        public enum Semester
        {
            Fall = 1,
            Spring = 2,
            Summer1 = 3,
            Summer2 = 4
        }

        public int Year { get; set; }
        public Semester SemesterName { get; set; }
    }
}
