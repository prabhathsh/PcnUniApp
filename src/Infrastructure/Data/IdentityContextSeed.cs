using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PcnUniApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcnUniApp.Infrastructure.Data
{
    public class IdentityContextSeed
    {
        public static async Task SeedAsync(CollegeIdentityDbContext identityContext, UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory, int? retryCount = 0)
        {
            int retryForAvailablity = retryCount.Value;

            try
            {
                if (!identityContext.Users.Any())
                {
                   foreach(var user in GetExistingUsers())
                    {
                      await  userManager.CreateAsync(user, "abcd@123Pwd");
                    }
                }
            }
            catch(Exception ex)
            {
                if(retryForAvailablity < 10)
                {
                    retryForAvailablity++;
                    var logger = loggerFactory.CreateLogger<CollegeIdentityDbContext>();
                    logger.LogError(ex.Message);
                    await SeedAsync(identityContext, userManager,  loggerFactory, retryForAvailablity);
                }
            }

        }


        private static IEnumerable<ApplicationUser> GetExistingUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser(){  FirstName  = "Bill", LastName ="John" ,  UserName ="admin12345678", DOB =Convert.ToDateTime("01/01/1965"), Email ="billjohn@abcd.org", EmailConfirmed = true },
              new ApplicationUser(){  FirstName  = "Adam", LastName ="Davis" ,  UserName ="stu12345678", DOB =Convert.ToDateTime("01/01/2000"), Email ="adamdavis@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Josh", LastName ="Brady" ,  UserName ="stu12355678", DOB =Convert.ToDateTime("02/11/2000"), Email ="joshbrady@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Ann", LastName ="Mendis" ,  UserName ="stu12345679", DOB =Convert.ToDateTime("03/11/2000"), Email ="annmendis@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Roger", LastName ="Smith" ,  UserName ="stu12345688", DOB =Convert.ToDateTime("11/11/2000"), Email ="rogersmoth@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Josh", LastName ="Tim" ,  UserName ="stu12345668", DOB =Convert.ToDateTime("05/21/2000"), Email ="timjosh@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Edd", LastName ="Martha" ,  UserName ="stu12344678", DOB =Convert.ToDateTime("06/01/2000"), Email ="eddmartha@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Neil", LastName ="Brian" ,UserName ="stu12343678", DOB =Convert.ToDateTime("07/23/2000"), Email ="neilbrian@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Baker", LastName ="Ward" , UserName ="stu12342678", DOB =Convert.ToDateTime("08/11/2000"), Email ="bakerward@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Peter", LastName ="Warner" ,  UserName ="stu12345688", DOB =Convert.ToDateTime("11/01/2000"), Email ="peterwarner@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Ian", LastName ="Maxwell" , UserName ="stu12333678", DOB =Convert.ToDateTime("12/01/2000"), Email ="ianmaxwell@abcd.org", EmailConfirmed = true},

              new ApplicationUser(){FirstName  = "Christy", LastName ="Fowller" ,  UserName ="sta12345678", DOB =Convert.ToDateTime("01/01/1985"), Email ="chrisfowller@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "David", LastName ="Smith" ,  UserName ="sta12355678", DOB =Convert.ToDateTime("02/11/1977"), Email ="davidsmith@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Keith", LastName ="Mendis" ,  UserName ="sta12345679", DOB =Convert.ToDateTime("03/11/1965"), Email ="keithmendis@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Jimmy", LastName ="Jones" ,  UserName ="sta12345688", DOB =Convert.ToDateTime("11/11/1982"), Email ="jimmyjones@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Jessica", LastName ="Tim" , UserName ="sta12345668", DOB =Convert.ToDateTime("05/21/1991"), Email ="bobtim@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Denzil", LastName ="Martha" ,  UserName ="sta12344678", DOB =Convert.ToDateTime("06/01/1977"), Email ="denzilmartha@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Nick", LastName ="Carter" ,  UserName ="sta12343678", DOB =Convert.ToDateTime("07/23/1989"), Email ="nickcarter@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Christian", LastName ="Ward" , UserName ="sta12342678", DOB =Convert.ToDateTime("08/11/1974"), Email ="christianward@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Anna", LastName ="River" , UserName ="sta12345688", DOB =Convert.ToDateTime("11/01/1965"), Email ="blakeriver@abcd.org", EmailConfirmed = true},
              new ApplicationUser(){FirstName  = "Tom", LastName ="Watson" , UserName ="sta12333678", DOB =Convert.ToDateTime("12/01/1988"), Email ="tomwatson@abcd.org", EmailConfirmed = true},

            };
        }
    }
}
