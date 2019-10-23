using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.ViewModels
{
    public class DeprtmentViewModel
    {
        public int DeprtmentId { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage ="Department Name is required")]
        [MaxLength(25)]
        public string DeprtmentName { get; set; }

        [Required(ErrorMessage  = "Department Budget is required")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage ="Department Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime  StartDate { get; set; }

        
    }
}
