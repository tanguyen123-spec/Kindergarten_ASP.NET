using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
  
        public interface IChiphiphuservice
        {
            Task<IEnumerable<Chiphiphu>> GetAll();
            Task<Chiphiphu> GetById(string id);
            Task Create(Chiphiphu entity);
            Task CreatebyModels(Chiphiphumodel chiphiphu);
            Task Update(string id, Chiphiphu entity);
            Task Delete(string id);
        Task<IEnumerable<Chiphiphu>> GetByChildResumeId(string childResumeId);
        Task DeleteByChildResumeId(string childResumeId);
        }

        public class ChiphiphuService : IChiphiphuservice
        {
            private readonly IRepository<Chiphiphu> _repository;
            private readonly MamnonProjectContext _context;

            public ChiphiphuService(IRepository<Chiphiphu> repository, MamnonProjectContext context)
            {
                _repository = repository;
                _context = context;
            }

            public async Task Create(Chiphiphu entity)
            {
                await _repository.Create(entity);
            }

            public async Task Delete(string id)
            {
                await _repository.Delete(id);
            }

            public async Task<IEnumerable<Chiphiphu>> GetAll()
            {
                return await _repository.GetAll();
            }

            public async Task<Chiphiphu> GetById(string id)
            {
                return await _repository.GetById(id);
            }

            public async Task Update(string id, Chiphiphu entity)
            {
                await _repository.Update(id, entity);
            }

            public async Task CreatebyModels(Chiphiphumodel chiphiphu)
            {
                var ch = new Chiphiphu
                {
                    Machiphiphu = chiphiphu.Machiphiphu,
                    Mahoatdong = chiphiphu.Mahoatdong,
                    Child_resume_id = chiphiphu.Child_resume_id,
                    Thang_namhoc = chiphiphu.Thang_namhoc
                };

                _context.Chiphiphus.Add(ch);
                await _context.SaveChangesAsync();
            }
        public async Task<IEnumerable<Chiphiphu>> GetByChildResumeId(string childResumeId)
        {
            return await _context.Chiphiphus.Where(c => c.Child_resume_id == childResumeId).ToListAsync();
        }
        public async Task DeleteByChildResumeId(string childResumeId)
        {
            var chiphuphus = await _context.Chiphiphus
                .Where(c => c.Child_resume_id == childResumeId)
                .ToListAsync();

            if (chiphuphus.Count > 0)
            {
                _context.Chiphiphus.RemoveRange(chiphuphus);
                await _context.SaveChangesAsync();
            }
        }
    }
    }

