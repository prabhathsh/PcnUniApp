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
    public class CreateModel : PageModel
    {
        private readonly IDepartmentViewModelService _departmentService;

        public CreateModel(IDepartmentViewModelService departmentService)
        {
            _departmentService = departmentService;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeprtmentViewModel department { get; set; }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           await  _departmentService.CreateDepartmentAsync(department);

            return RedirectToPage("./Index");
        }



       
    }
}