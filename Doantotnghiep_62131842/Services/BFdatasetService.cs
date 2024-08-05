using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IBFdatasetService
    {
        Task<IEnumerable<BFdataset>> GetAll();
        Task<BFdataset> GetById(string id);
        Task Create(BFdataset entity);
        Task Update(string id, BFdataset entity);
        Task Delete(string id);
        Task DeleteAll();
    }

    public class BFdatasetService : IBFdatasetService
    {
        private readonly IRepository<BFdataset> _repository;

        public BFdatasetService(IRepository<BFdataset> repository)
        {
            _repository = repository;
        }

        public async Task Create(BFdataset entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<BFdataset>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<BFdataset> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, BFdataset entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task DeleteAll()
        {
            var allData = await _repository.GetAll();

            foreach (var data in allData)
            {
                await _repository.Delete(data.BFastid);
            }
        }
    }
}
