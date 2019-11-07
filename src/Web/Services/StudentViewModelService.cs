using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.ApplicationCore.Interfaces;
using PcnUniApp.ApplicationCore.Specifications;
using PcnUniApp.Web.Interfaces;
using PcnUniApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PcnUniApp.ApplicationCore.Entities.Student;

namespace PcnUniApp.Web.Services
{
    public class StudentViewModelService : IStudentViewModelService
    {

        private readonly ILogger<StudentViewModelService> _logger;
        private readonly IAsyncRepository<Student> _studentRepository;
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IUriComposer _uriComposer;
        public StudentViewModelService(ILoggerFactory loggerFactory,
                                        IAsyncRepository<Student> studentRepository,
                                        IAsyncRepository<Department> departmentRepository,
                                        IUriComposer uriComposer )
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _uriComposer = uriComposer;
            _logger = loggerFactory.CreateLogger<StudentViewModelService>();
        }
        public async Task CreateStudentAsync(StudentViewModel studentVM)
        {
            _logger.LogInformation("CreateStudentAsync is called");
            var student = new Student()
            {
                DateOfBirth = studentVM.DateOfBirth,
                DepartmentId = studentVM.DepartmentId,
                Email = studentVM.Email,
                FirstName = studentVM.FirstName,
                LastName  = studentVM.LastName,
                Gender = GetStudentGender(studentVM.Gender),
               MiddleName  = studentVM.MiddleName 
                
            };

            await _studentRepository.AddAsync(student);
        }

        public async  Task<StudentViewModel> GetStudentById(int id)
        {
            _logger.LogInformation("GetStudentById is called");
            var student =await  _studentRepository.GetByIdAsync(id);
            if (student == null)
                return null;

            var studentVM = new StudentViewModel()
            {
                DateOfBirth = student.DateOfBirth,
                DepartmentId = student.DepartmentId,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FullName = $"{student.FirstName} {student.MiddleName ?? string.Empty} {student.LastName}",
                StudentNumber = student.StudentNumber,
                Gender = Convert.ToString(student.Gender)
            };


            return studentVM;
        }

        public async  Task<StudentIndexViewModel> GetStudents(int pageIndex, int itemsPage, string searchFilter, int? departmentId)
        {
            _logger.LogInformation("GetStudents is called");

           var studentsInfo = await  _studentRepository.ListAsync(new StudentFilterSpecification(searchFilter, departmentId));
            var departments = await _departmentRepository.ListAllAsync();
            var studentVM = new StudentIndexViewModel()
            {
                Students = studentsInfo.Select(s => new StudentViewModel()
                {
                    DateOfBirth = s.DateOfBirth,
                    DepartmentId = s.DepartmentId,
                    DepartmentName = departments.FirstOrDefault(d => d.Id == s.DepartmentId).Name,
                    Email = s.Email,
                    FullName = string.Format("{0}{1} {2}", s.FirstName, string.IsNullOrWhiteSpace(s.MiddleName) ? string.Empty : " " + s.MiddleName, s.LastName),
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentId = s.Id,
                    StudentNumber = s.StudentNumber,
                    Gender = Enum.GetName(typeof(GenderValues), s.Gender)

                }),
                
                DepartmentFilterApplied  = departmentId ??0,
                SearchFilter  = string.IsNullOrWhiteSpace(searchFilter)?string.Empty:searchFilter,
                Departments =  await GetDepartments(),
                GenderTypes = GetGender()
            };

            return studentVM;
        }

        public async  Task UpdateStudentAsync(StudentViewModel studentVM)
        {
            _logger.LogInformation("UpdateStudentAsync is called");
            var student = new Student()
            {
                Id   = studentVM.StudentId,
                DateOfBirth = studentVM.DateOfBirth,
                DepartmentId = studentVM.DepartmentId,
                Email = studentVM.Email,
                FirstName = studentVM.FirstName,
                LastName = studentVM.LastName,
                StudentNumber = studentVM.StudentNumber,
                Gender = GetStudentGender(studentVM.Gender)
            };
            await _studentRepository.UpdateAsync(student);

        }

        public async Task<List<SelectListItem>> GetDepartments()
        {
            var departments = await  _departmentRepository.ListAllAsync();

            var items = new List<SelectListItem>() {
               new  SelectListItem(){Value  = null, Text = "Select", Selected  = false}
            };

            foreach(var department in departments )
            {
                items.Add(new SelectListItem(department.Name, department.Id.ToString()));
            }

            return items;
                
        }       

        private GenderValues GetStudentGender(string gender)
        {
            GenderValues stuGender;
            Enum.TryParse(gender, out stuGender);
            return stuGender;
        }

        private List<SelectListItem> GetGender()
        {
            var genderTypes = Enum.GetValues(typeof(Student.GenderValues));

            var items = new List<SelectListItem>() { new SelectListItem()
                {
                    Value  = null, Text = "Select", Selected  = false
                }
            };

            foreach(var val in genderTypes)
            {
                items.Add(new SelectListItem(Convert.ToString((Student.GenderValues)val), Convert.ToString((int)val)));
            }

            return items;
        }


       
    }
}
