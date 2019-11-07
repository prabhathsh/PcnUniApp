using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate;
using PcnUniApp.ApplicationCore.Entities.StudentEnrollmentAggregate;
using System;
using static PcnUniApp.ApplicationCore.Entities.SemesterCoursesAggregate.SectionLocation;
using static PcnUniApp.ApplicationCore.Entities.SemesterYear;
using static PcnUniApp.ApplicationCore.Entities.Student;

namespace PcnUniApp.Infrastructure.Data
{
   public  class CollegeContext : DbContext
    {
        public CollegeContext(DbContextOptions<CollegeContext> options) :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<EnrollmentSection> EnrollmentSections { get; set; }
        public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<SectionLocation> SectionLocations { get; set; }
        public DbSet<SectionInstructor> SectionInstructors { get; set; }
        public DbSet<SemesterCourse> SemesterCourses { get; set; }
        public DbSet<SemesterYear> SemesterYears { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>(ConfigureDeprtment);
            builder.Entity<Student>(ConfigureStudent);
            builder.Entity<Instructor>(ConfigureInstructor);
            builder.Entity<CoursePrerequisite>(ConfigureCoursePrerequisite);
            builder.Entity<Course>(ConfigureCourse);
            builder.Entity<StudentEnrollment>(ConfigureStudentEnrollment);
            builder.Entity<EnrollmentSection>(ConfigureEnrollmentSection);           
            builder.Entity<CourseSection>(ConfigureCourseSection);
            builder.Entity<SectionLocation>(ConfigureSectionLocation);
            builder.Entity<SectionInstructor>(ConfigureSectionInstructor);
            builder.Entity<SemesterCourse>(ConfigureSemesterCourse);
            builder.Entity<SemesterYear>(ConfigureSemesterYear);
        }

        private void ConfigureSemesterYear(EntityTypeBuilder<SemesterYear> obj)
        {
            obj.ToTable("SemesterYear");
            obj.HasKey(s => s.Id);
            obj.Property(s => s.Id)
                .UseHiLo("semester_year_hilo")
                .IsRequired();
            obj.Property(s => s.Year).IsRequired();
            obj.Property(s => s.SemesterName).HasMaxLength(50)
                .HasConversion(s => s.ToString(), s => (Semester)Enum.Parse(typeof(Semester), s));
        }

        private void ConfigureSemesterCourse(EntityTypeBuilder<SemesterCourse> obj)
        {
            obj.ToTable("SemesterCourse");
            var naviProperty = obj.Metadata.FindNavigation(nameof(SemesterCourse.CourseSections));
            naviProperty.SetPropertyAccessMode(PropertyAccessMode.Field);

            obj.OwnsOne(s => s.SemesterOfferedCourse);
            obj.Property(s => s.NumberOfCredits).IsRequired(true);
        }

        private void ConfigureSectionInstructor(EntityTypeBuilder<SectionInstructor> obj)
        {
            obj.ToTable("SectionInstructor");
            obj.Property(s => s.InstructorId).IsRequired(true);
        }

        private void ConfigureSectionLocation(EntityTypeBuilder<SectionLocation> obj)
        {
            obj.ToTable("SectionLocation");
            obj.Property(l => l.SectionDay)
                .HasConversion(v => v.ToString(),
                            v => (Day)Enum.Parse(typeof(Day), v))
                .IsRequired(true);

            obj.Property(l => l.Location)
               .HasMaxLength(25)
               .IsRequired(true);

            obj.Property(l => l.StartTime)
                .HasMaxLength(10)
                .IsRequired(true);

            obj.Property(l => l.EndTime)
                .HasMaxLength(10)
                .IsRequired(true);
        }

        private void ConfigureCourseSection(EntityTypeBuilder<CourseSection> obj)
        {
            obj.ToTable("CourseSection");
            var locNavigation = obj.Metadata.FindNavigation(nameof(CourseSection.SectionLocations));
            locNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var incNavigation = obj.Metadata.FindNavigation(nameof(CourseSection.SectionInstructors));
            incNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            obj.Property(s => s.Capacity)
               .IsRequired(true);


        }

        private void ConfigureCoursePrerequisite(EntityTypeBuilder<CoursePrerequisite> obj)
        {
            obj.ToTable("CoursePrerequisite");
            //obj.Property(p => p.CourseId)
            //    .IsRequired(true);
            //obj.Property(p => p.PrerequisiteCourseId)
            //     .IsRequired(true);


            //obj.HasOne(i => i.Course)
            //  .WithMany()
            //  .HasForeignKey(i => i.CourseId);

            //obj.HasOne(i => i.PrerequisiteCourse)
            //   .WithMany()
            //   .HasForeignKey(i => i.PrerequisiteCourseId).OnDelete(DeleteBehavior.Restrict);

            ////TODO  - Need to find a way to add unique key index
            //obj.HasIndex(p => new { p.CourseId , p.PrerequisiteCourseId });

            obj.HasIndex(e => new { e.CourseId, e.PrerequisiteCourseId })
                   .HasName("UK_CourseId_PrerequisiteCourseId")
                   .IsUnique();

            obj.HasOne(d => d.Course)
                    .WithMany(p => p.PrerequisiteCourse)
                    .HasForeignKey(d => d.CourseId);

            obj.HasOne(d => d.PrerequisiteCourse)
                .WithMany(p => p.CurrentCourse)
                .HasForeignKey(d => d.PrerequisiteCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }

        private void ConfigureEnrollmentSection(EntityTypeBuilder<EnrollmentSection> obj)
        {
            obj.ToTable("EnrollmentSection");
          
            obj.Property(p => p.CourseId)
                 .IsRequired(true);

            obj.Property(p => p.EnrolleedDate)
                 .IsRequired(true);

            obj.Property(p => p.NumberOfCredits)
                 .IsRequired(true);

            obj.Property(p => p.SectionId)
                 .IsRequired(true);

            obj.Property(p => p.SemesterCourseId)
                .IsRequired(true);
        }

        private void ConfigureStudentEnrollment(EntityTypeBuilder<StudentEnrollment> obj)
        {
            obj.ToTable("StudentEnrollment");

            obj.Property(e => e.StudentId)
                .IsRequired();

            obj.Property(e => e.SemesterYearId)
                .IsRequired();

            obj.Property(e => e.EnrolledDate)
                .IsRequired();


            var navigationEnrollement = obj.Metadata.FindNavigation(nameof(StudentEnrollment.EnrollmentSections));
            navigationEnrollement.SetPropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }

        private void ConfigureCourse(EntityTypeBuilder<Course> obj)
        {
            obj.ToTable("Course");

            obj.HasKey(ci => ci.Id);

            obj.Property(ci => ci.Id)
               .UseHiLo("Course_hilo")
               .IsRequired();

            obj.HasIndex(ci => ci.Code)
                .IsUnique();

            obj.Property(cs => cs.Code)
                .IsRequired()
                .HasMaxLength(10);

            obj.Property(cs => cs.Title)
                .IsRequired()
                .HasMaxLength(50);

            obj.Property(cs => cs.Description)
                .IsRequired()
                .HasMaxLength(500);

           // var navigationCourses = obj.Metadata.FindNavigation(nameof(Course.CoursePrerequisites));
            //navigationCourses.SetPropertyAccessMode(PropertyAccessMode.Field);


            // var navigation = modelBuilder.Entity<Person>().Metadata.FindNavigation(nameof(PersonProduct));
            // navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //  obj.HasMany(p => p.C)
            //.WithRequired(d => d.Offspring)
            //.HasForeignKey(d => d.OffspringId)
            //.WillCascadeOnDelete(false);

            // has many offspring
            //HasMany(p => p.Offspring)
            //    .WithRequired(d => d.Ancestor)
            //    .HasForeignKey(d => d.AncestorId)
            //    .WillCascadeOnDelete(false);
        }

        private void ConfigureInstructor(EntityTypeBuilder<Instructor> obj)
        {
            obj.ToTable("Instructor");

            obj.HasKey(i => i.Id);

            obj.Property(i => i.Id)
                .UseHiLo("Instructor_hilo");

            obj.Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(25);
            obj.Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(25);

            obj.Property(i => i.Email)
              .IsRequired()
              .HasMaxLength(50);

            obj.Property(i => i.MiddleName)
                .IsRequired(false)
                .HasMaxLength(25);

            obj.Property(i => i.OfficeLocation)
                .IsRequired(false)
                .HasMaxLength(50);
        }

        private void ConfigureStudent(EntityTypeBuilder<Student> obj)
        {
            obj.ToTable("Student");
            obj.HasKey(s => s.Id);

            obj.Property(s => s.Id)
                .UseHiLo("Student_hilo");

            obj.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            obj.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(25);

            obj.Property(s => s.MiddleName)
                .IsRequired(false)
                .HasMaxLength(25);

            obj.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(50);

            obj.Property(s => s.DateOfBirth)
                .HasColumnType("Date")
                .IsRequired(true);

            obj.Property(s => s.Gender).HasMaxLength(25)
                .HasConversion(s => s.ToString(), s => (GenderValues)Enum.Parse(typeof(GenderValues),s))
                .IsRequired(true);
            
        }

        private void ConfigureDeprtment(EntityTypeBuilder<Department> obj)
        {
            obj.ToTable("Department");

            obj.HasKey(d => d.Id);
            obj.Property(d => d.Id)
                .UseHiLo("Department_hilo");

            obj.HasIndex(d => d.Name)
                .IsUnique(true);

            obj.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(25);

            obj.Property(d => d.StartDate)
                .IsRequired();

            obj.Property(d => d.Budget)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            var navigationCourses = obj.Metadata.FindNavigation(nameof(Department.Courses));
            navigationCourses.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationStudent = obj.Metadata.FindNavigation(nameof(Department.Students));
            navigationCourses.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationInstructor = obj.Metadata.FindNavigation(nameof(Department.Instructors));
            navigationInstructor.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
