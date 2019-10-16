using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.Infrastructure.Identity
{
    public class CollegeIdentityDbContext  : IdentityDbContext<ApplicationUser>
    {

        public CollegeIdentityDbContext(DbContextOptions<CollegeIdentityDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(ConfigureApplicationUser);

        }

        private void ConfigureApplicationUser(EntityTypeBuilder<ApplicationUser> obj)
        {
            obj.Property(p => p.FirstName).HasMaxLength(25);
            obj.Property(p => p.LastName).HasMaxLength(25);
        }
    }
}
