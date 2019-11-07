using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.ViewModels
{
    public class StudentIndexViewModel
    {
        public IEnumerable<StudentViewModel> Students { get; set; }
        public string SearchFilter { get; set; }
        public int? DepartmentFilterApplied { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> GenderTypes { get; set; }
    }
}
