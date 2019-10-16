using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.Infrastructure.Identity
{
   public  class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]

        public string LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
