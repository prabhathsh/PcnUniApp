using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate
{
    public class SectionLocation : BaseEntity
    {
        public enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        private SectionLocation() { }
        public SectionLocation(Day day, string location, string startTime, string endTime)
        {
            SectionDay = day;
            Location = location;
            StartTime = startTime;
            EndTime = endTime;
        }
        public Day SectionDay { get; private set; }

        public string Location { get; private set; }

        public string StartTime { get; set; }

        public string EndTime { get; private set; }
    }
}
