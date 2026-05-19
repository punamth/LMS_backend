using LMS.Domain.Entities;

namespace LMS.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Lesson> Lessons { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Enrollment> Enrollments { get; }
        IGenericRepository<Progress> Progress { get; }
        IGenericRepository<Test> Tests { get; }
        IGenericRepository<TestAttempt> TestAttempts { get; }

        Task<int> CompleteAsync();
    }
}
