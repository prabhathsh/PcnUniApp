using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcnUniApp.ApplicationCore.Entities.StudentEnrollmentAggregate
{   
    public class StudentEnrollment : BaseEntity, IAggregateRoot
    {

        public int StudentId { get; private set; }
        public int SemesterYearId { get; private set; }
        public DateTime EnrolledDate { get; set; }

        private readonly List<EnrollmentSection> _enrollementSections = new List<EnrollmentSection>();
        public IReadOnlyCollection<EnrollmentSection> EnrollmentSections => _enrollementSections.AsReadOnly();
        // public List<EnrollmentSection> EnrolementSections => _enrollementSections;//.AsReadOnly();

        private StudentEnrollment()
        {

        }

        //public StudentEnrollment(int studentId, int semesterYearId)
        //{
        //    StudentId = studentId;
        //    SemesterYearId = semesterYearId;
        //    EnrolledDate = DateTime.Now;
        //}

        public StudentEnrollment(int studentId, int semesterYearId, List<EnrollmentSection> enrollementSections)
        {
            StudentId = studentId;
            SemesterYearId = semesterYearId;
            EnrolledDate = DateTime.Now;
            _enrollementSections = enrollementSections;
        }

        public void AddEnrollment(int courseId, int semesterCourseId,
            int sectionId, int numberOfCredits)
        {
            if (!EnrollmentSections.Any(e => e.SemesterCourseId == semesterCourseId))
            {
                _enrollementSections.Add(new EnrollmentSection(courseId,
                                    semesterCourseId, sectionId, numberOfCredits)
                {

                });


            }
        }

        //public void RemoveEnrollment(int sectionId)
        //{
        //    _enrollementSections.Remove(s => s.Id == sectionId);
        //}

        //public StudentEnrollment(int studentId, List<EnrollmentSection> enrolementSections )
        //{
        //    StudentId = studentId;
        //    _enrollementSections = enrolementSections;
        //}

    }
}
