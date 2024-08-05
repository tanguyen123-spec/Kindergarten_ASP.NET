using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IAFnoondatasetService
    {
        Task<IEnumerable<AFnoondataset>> GetAll();
        Task<AFnoondataset> GetById(string id);
        Task Create(AFnoondataset entity);
        Task Update(string id, AFnoondataset entity);
        Task Delete(string id);
    }

    public class AFnoondatasetService : IAFnoondatasetService
    {
        private readonly IRepository<AFnoondataset> _repository;

        public AFnoondatasetService(IRepository<AFnoondataset> repository)
        {
            _repository = repository;
        }

        public async Task Create(AFnoondataset entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<AFnoondataset>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<AFnoondataset> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, AFnoondataset entity)
        {
            await _repository.Update(id, entity);
        }
    }
}
