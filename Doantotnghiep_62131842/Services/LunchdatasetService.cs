using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface ILunchdatasetService
    {
        Task<IEnumerable<Lunchdataset>> GetAll();
        Task<Lunchdataset> GetById(string id);
        Task Create(Lunchdataset entity);
        Task Update(string id, Lunchdataset entity);
        Task Delete(string id);
    }

    public class LunchdatasetService : ILunchdatasetService
    {
        private readonly IRepository<Lunchdataset> _repository;

        public LunchdatasetService(IRepository<Lunchdataset> repository)
        {
            _repository = repository;
        }

        public async Task Create(Lunchdataset entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Lunchdataset>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Lunchdataset> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Lunchdataset entity)
        {
            await _repository.Update(id, entity);
        }
    }
}
