using Microsoft.Extensions.Logging;
using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcnUniApp.Infrastructure.Data
{
    public class CollegeContextSeed
    {
        public static async Task SeedAsync(CollegeContext collegeContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if(!collegeContext.Departments.Any())
                {
                    collegeContext.Departments.AddRange(GetExistingDepartments());
                    await collegeContext.SaveChangesAsync();

                    collegeContext.Students.AddRange(GetExistingStudents());
                    await collegeContext.SaveChangesAsync();

                    collegeContext.Instructors.AddRange(GetExistingInstructors());
                    await collegeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                if(retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CollegeContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(collegeContext,  loggerFactory, retryForAvailability);
                }
            }
        }


        private static IEnumerable<Department>  GetExistingDepartments()
        {
            return new List<Department>()
            {
                new Department(){ Name = "Computer Science" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Biology" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Plant Bilogy" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Economics" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Industrial Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Electrical Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Mechanical Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Mangagement" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Zology" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Petrolium Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Geoligy" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Agriculture" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},


            };
        }


        private static IEnumerable<Student> GetExistingStudents()
        {
            return new List<Student>()
            {
                 new Student(){  DepartmentId  = 1, FirstName  = "Adam", LastName ="Davis" ,Gender  = Student.GenderValues.Male,  StudentNumber ="stu12345678", DateOfBirth =Convert.ToDateTime("01/01/2000"), Email ="adamdavis@abcd.org"},
              new Student(){  DepartmentId  = 1, FirstName  = "Josh", LastName ="Brady" , Gender  = Student.GenderValues.Male,  StudentNumber ="stu12355678", DateOfBirth =Convert.ToDateTime("02/11/2000"), Email ="joshbrady@abcd.org"},
              new Student(){  DepartmentId  = 2, FirstName  = "Ann", LastName ="Mendis" , Gender  = Student.GenderValues.Female , StudentNumber ="stu12345679", DateOfBirth =Convert.ToDateTime("03/11/2000"), Email ="annmendis@abcd.org"},
              new Student(){  DepartmentId  = 2, FirstName  = "Roger", LastName ="Smith" ,  Gender  = Student.GenderValues.Male, StudentNumber ="stu12345688", DateOfBirth =Convert.ToDateTime("11/11/2000"), Email ="rogersmoth@abcd.org"},
              new Student(){  DepartmentId  = 2, FirstName  = "Josh", LastName ="Tim" , Gender  = Student.GenderValues.Male,  StudentNumber ="stu12345668", DateOfBirth =Convert.ToDateTime("05/21/2000"), Email ="timjosh@abcd.org"},
              new Student(){  DepartmentId  = 3, FirstName  = "Edd", LastName ="Martha" , Gender  = Student.GenderValues.Male,  StudentNumber ="stu12344678", DateOfBirth =Convert.ToDateTime("06/01/2000"), Email ="eddmartha@abcd.org"},
              new Student(){  DepartmentId  = 4,FirstName  = "Neil", LastName ="Brian" , Gender  = Student.GenderValues.Male, StudentNumber ="stu12343678", DateOfBirth =Convert.ToDateTime("07/23/2000"), Email ="neilbrian@abcd.org"},
              new Student(){  DepartmentId  = 5, FirstName  = "Baker", LastName ="Ward" , Gender  = Student.GenderValues.Male, StudentNumber ="stu12342678", DateOfBirth =Convert.ToDateTime("08/11/2000"), Email ="bakerward@abcd.org"},
              new Student(){   DepartmentId  = 6 ,FirstName  = "Peter", LastName ="Warner" , Gender  = Student.GenderValues.Male, StudentNumber ="stu12345688", DateOfBirth =Convert.ToDateTime("11/01/2000"), Email ="peterwarner@abcd.org"},
              new Student(){   DepartmentId  = 7,FirstName  = "Ian", LastName ="Maxwell" , Gender  = Student.GenderValues.Male, StudentNumber ="stu12333678", DateOfBirth =Convert.ToDateTime("12/01/2000"), Email ="ianmaxwell@abcd.org"},
            };
        }



        private static IEnumerable<Instructor> GetExistingInstructors()
        {
            return new List<Instructor>()
            {
              new Instructor(){DepartmentId = 1, FirstName  = "Christy", LastName ="Fowller" , OfficeLocation ="Room 423", InstructorNumber ="sta12345678",  Email ="chrisfowller@abcd.org"},
              new Instructor(){DepartmentId=2, FirstName  = "David", LastName ="Smith" , OfficeLocation ="Room 323", InstructorNumber ="sta12355678",  Email ="davidsmith@abcd.org"},
              new Instructor(){DepartmentId = 3, FirstName  = "Keith", LastName ="Mendis" , OfficeLocation ="Room 133", InstructorNumber ="sta12345679", Email ="keithmendis@abcd.org"},
              new Instructor(){DepartmentId = 4,FirstName  = "Jimmy", LastName ="Jones" , OfficeLocation ="Room 56", InstructorNumber ="sta12345688", Email ="jimmyjones@abcd.org"},
              new Instructor(){DepartmentId = 5, FirstName  = "Jessica", LastName ="Tim" , OfficeLocation ="Room 323", InstructorNumber ="sta12345668", Email ="bobtim@abcd.org"},
              new Instructor(){DepartmentId = 6,FirstName  = "Denzil", LastName ="Martha" , OfficeLocation ="Room 120", InstructorNumber ="sta12344678",  Email ="denzilmartha@abcd.org"},
              new Instructor(){DepartmentId = 7, FirstName  = "Nick", LastName ="Carter" , OfficeLocation ="Room 423", InstructorNumber ="sta12343678", Email ="nickcarter@abcd.org"},
              new Instructor(){DepartmentId = 3,FirstName  = "Christian", LastName ="Ward" , OfficeLocation ="Room 223", InstructorNumber ="sta12342678",  Email ="christianward@abcd.org"},
              new Instructor(){DepartmentId = 2,FirstName  = "Anna", LastName ="River" , OfficeLocation ="Room 122", InstructorNumber ="sta12345688",  Email ="blakeriver@abcd.org"},
              new Instructor(){DepartmentId = 1,FirstName  = "Tom", LastName ="Watson" , OfficeLocation ="Room 123", InstructorNumber ="sta12333678",  Email ="tomwatson@abcd.org"},

            };
        }


    }
}
