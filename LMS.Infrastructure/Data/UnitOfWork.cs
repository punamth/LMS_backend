using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Infrastructure;

namespace LMS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Courses = new GenericRepository<Course>(_context);
            Lessons = new GenericRepository<Lesson>(_context);
            Users = new GenericRepository<User>(_context);
            Enrollments = new GenericRepository<Enrollment>(_context);
            Progresses = new GenericRepository<Progress>(_context);
            Tests = new GenericRepository<Test>(_context);
            TestAttempts = new GenericRepository<TestAttempt>(_context);
        }

        public IGenericRepository<Course> Courses { get; private set; }
        public IGenericRepository<Lesson> Lessons { get; private set; }
        public IGenericRepository<User> Users { get; private set; }
        public IGenericRepository<Enrollment> Enrollments { get; private set; }
        public IGenericRepository<Progress> Progress => Progresses; // <-- Added to implement interface
        public IGenericRepository<Progress> Progresses { get; private set; }
        public IGenericRepository<Test> Tests { get; private set; }
        public IGenericRepository<TestAttempt> TestAttempts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
