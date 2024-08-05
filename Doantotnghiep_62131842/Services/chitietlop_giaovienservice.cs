using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface Ichitietgiaovien_lopservice
    {
        Task<IEnumerable<ChitietgiaovienLop>> GetAll();
        Task<ChitietgiaovienLop> GetById(string id);
        Task Create(ChitietgiaovienLop entity);
        Task Update(string id, ChitietgiaovienLop entity);
        Task Delete(string id);

    }
    public class chitietlop_giaovienservice : Ichitietgiaovien_lopservice
    {
        private readonly IRepository<ChitietgiaovienLop> _repository;
        private readonly MamnonProjectContext _context;
        public chitietlop_giaovienservice(IRepository<ChitietgiaovienLop> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(ChitietgiaovienLop entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ChitietgiaovienLop>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ChitietgiaovienLop> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, ChitietgiaovienLop entity)
        {
            await _repository.Update(id, entity);
        }
      


    }
}
