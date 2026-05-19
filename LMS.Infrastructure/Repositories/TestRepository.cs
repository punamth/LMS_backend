using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Test> AddAsync(Test entity)
        {
            _context.Tests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Test entity)
        {
            _context.Tests.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> FindAsync(Expression<Func<Test, bool>> predicate)
        {
            return await _context.Tests.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test?> GetByIdAsync(int id)
        {
            return await _context.Tests.FindAsync(id);
        }

        public async Task UpdateAsync(Test entity)
        {
            _context.Tests.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
