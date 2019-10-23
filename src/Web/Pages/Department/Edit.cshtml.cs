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
    public class EditModel : PageModel
    {

        private readonly IDepartmentViewModelService _departmentService;

        public EditModel(IDepartmentViewModelService departmentService)
        {
            _departmentService = departmentService;
        }


        [BindProperty]
        public DeprtmentViewModel department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            department =await  _departmentService.GetDepartmentById(id.Value);
            if (department == null)
                return NotFound();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentService.UpdateDepartmentAsync(department);

            return RedirectToPage("./Index");
        }

    }
}