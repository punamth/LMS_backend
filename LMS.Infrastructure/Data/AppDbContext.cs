using LMS.Domain.Entities;
using LMS.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply EF Core configurations
            modelBuilder.ApplyConfiguration(new TestConfiguration());

        }
    }
}
