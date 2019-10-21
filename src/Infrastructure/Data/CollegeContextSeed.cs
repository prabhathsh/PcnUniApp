using Microsoft.Extensions.Logging;
using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcnUniApp.Infrastructure.Data
{
    public class CollegeContextSeed
    {
        public static async Task SeedAsync(CollegeContext collegeContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if(!collegeContext.Departments.Any())
                {
                    collegeContext.Departments.AddRange(GetExistingDepartments());
                    await collegeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                if(retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CollegeContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(collegeContext, loggerFactory, retryForAvailability);
                }
            }
        }


        private static IEnumerable<Department>  GetExistingDepartments()
        {
            return new List<Department>()
            {
                new Department(){ Name = "Computer Science" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Biology" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Plant Bilogy" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Economics" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Industrial Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Electrical Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Mechanical Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Mangagement" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Zology" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Petrolium Engineering" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Geoligy" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},
                new Department(){ Name = "Agriculture" , StartDate = Convert.ToDateTime("01/01/1980"),Budget  = 1234567.99M},


            };
        }


    }
}
