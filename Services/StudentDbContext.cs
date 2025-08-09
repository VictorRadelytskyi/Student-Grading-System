using Microsoft.EntityFrameworkCore;

namespace StudentGradingSystem.Services
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    }
}
