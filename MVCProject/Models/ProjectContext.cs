using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class ProjectContext:DbContext
    {

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        public ProjectContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MVCProject;Integrated Security=True;TrustServerCertificate=True"
                );
            base.OnConfiguring(optionsBuilder);
        }

    }
}
