using Microsoft.AspNetCore.Mvc.Rendering;
using PcnUniApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.Interfaces
{
    public interface IStudentViewModelService
    {
        Task<StudentIndexViewModel> GetStudents(int pageIndex, int itemsPage, string searchFilter, int? departmentId);

        Task CreateStudentAsync(StudentViewModel student);

        Task UpdateStudentAsync(StudentViewModel student);

        Task<StudentViewModel> GetStudentById(int id);

        Task<List<SelectListItem>> GetDepartments();
    }
}
