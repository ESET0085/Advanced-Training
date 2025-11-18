using CourseApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext>options):base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}
        public DbSet<Course> Courses { get; set; }
    }
}
