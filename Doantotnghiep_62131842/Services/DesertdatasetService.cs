using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IDesertdatasetService
    {
        Task<IEnumerable<Desertdataset>> GetAll();
        Task<Desertdataset> GetById(string id);
        Task Create(Desertdataset entity);
        Task Update(string id, Desertdataset entity);
        Task Delete(string id);
    }

    public class DesertdatasetService : IDesertdatasetService
    {
        private readonly IRepository<Desertdataset> _repository;

        public DesertdatasetService(IRepository<Desertdataset> repository)
        {
            _repository = repository;
        }

        public async Task Create(Desertdataset entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Desertdataset>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Desertdataset> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Desertdataset entity)
        {
            await _repository.Update(id, entity);
        }
    }
}
