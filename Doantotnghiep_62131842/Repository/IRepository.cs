using Doantotnghiep_62131842.Entity;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }

    public class MyRepository<T> : IRepository<T> where T : class
    {
        private readonly MamnonProjectContext _context;

        public MyRepository(MamnonProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string id, T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
