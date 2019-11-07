using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PcnUniApp.Web.Interfaces;
using PcnUniApp.Web.Services;
using PcnUniApp.Web.ViewModels;

namespace PcnUniApp.Web.Pages.Student
{
    public class IndexModel : PageModel
    {

        private readonly IStudentViewModelService _studentViewModelService;
        private readonly ILogger<StudentViewModelService> _logger;
        public IndexModel(IStudentViewModelService studentViewModelService,
                          ILoggerFactory loggerFactory)
        {
            _studentViewModelService = studentViewModelService;
            _logger = loggerFactory.CreateLogger<StudentViewModelService>();
        }

      
        public StudentIndexViewModel StudentModel { get; set; } = new StudentIndexViewModel();
        
        public async Task OnGetAsync(StudentIndexViewModel studentModel)
        {
            StudentModel = await _studentViewModelService.GetStudents(0, Constants.ITEMS_PER_PAGE, studentModel.SearchFilter , studentModel.DepartmentFilterApplied );

        }
    }
}