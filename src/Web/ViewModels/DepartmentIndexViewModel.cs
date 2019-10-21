using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.ViewModels
{
    public class DepartmentIndexViewModel
    {
        public IEnumerable<DeprtmentViewModel> Departments { get; set; }
        public string SearchFilter { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
