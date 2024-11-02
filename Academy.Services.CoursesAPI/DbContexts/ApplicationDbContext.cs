using Microsoft.EntityFrameworkCore;
using Academy.Services.CourseAPI.Models;

namespace Academy.Services.CourseAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }

        public DbSet<Course> Courses { get; set; }
    }
}
