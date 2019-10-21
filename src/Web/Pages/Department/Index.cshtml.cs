using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PcnUniApp.Web.Interfaces;
using PcnUniApp.Web.ViewModels;

namespace PcnUniApp.Web.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentViewModelService _departmentService;

        public IndexModel(IDepartmentViewModelService departmentService)
        {
            _departmentService = departmentService;
        }

        public DepartmentIndexViewModel departments;

        [BindProperty(SupportsGet = true)]
        public string searchFilter { get; set; }

        public async Task  OnGetAsync()
        {
            departments = await _departmentService.GetDeprtments(0, Constants.ITEMS_PER_PAGE, searchFilter);
        }
    }
}