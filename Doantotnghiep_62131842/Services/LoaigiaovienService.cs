using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface ILoaigiaovienService
    {
        Task<IEnumerable<Loaigiaovien>> GetAll();
        Task<Loaigiaovien> GetById(string id);
        Task Create(Loaigiaovien entity);
        Task CreatebyModels(LoaigiaovienModel loaigiaovien);
        Task Update(string id, Loaigiaovien entity);
        Task Delete(string id);

    }
    public class LoaigiaovienService : ILoaigiaovienService
    {
        private readonly IRepository<Loaigiaovien> _repository;
        private readonly MamnonProjectContext _context;
        public LoaigiaovienService(IRepository<Loaigiaovien> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Loaigiaovien entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Loaigiaovien>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Loaigiaovien> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Loaigiaovien entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(LoaigiaovienModel loaigiaovien)
        {
            var lgv = new Loaigiaovien
            {


                Maloaigiaovien = loaigiaovien.Maloaigiaovien,
                Tenloaigiaovien = loaigiaovien.Tenloaigiaovien,


            };
            _context.Loaigiaoviens.Add(lgv);
            await _context.SaveChangesAsync();
        }
       


    }
}
