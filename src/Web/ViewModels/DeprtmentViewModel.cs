using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.ViewModels
{
    public class DeprtmentViewModel
    {
        public int DeprtmentId { get; set; }
        public string DeprtmentName { get; set; }
        public decimal Budget { get; set; }
        public DateTime  StartDate { get; set; }
    }
}
