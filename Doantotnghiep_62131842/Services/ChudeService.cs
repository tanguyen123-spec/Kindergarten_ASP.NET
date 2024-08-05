using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
   
    public interface IChudeService
    {
        Task<IEnumerable<Chude>> GetAll();
        Task<Chude> GetById(string id);
        Task Create(Chude entity);
        Task CreatebyModels(ChudeModel chude);
        Task Update(string id, Chude entity);
        Task Delete(string id);

    }
    public class ChudeService : IChudeService
    {
        private readonly IRepository<Chude> _repository;
        private readonly MamnonProjectContext _context;
        public ChudeService(IRepository<Chude> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Chude entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Chude>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Chude> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Chude entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(ChudeModel chude)
        {
            var cd = new Chude
            {
                  
                Machude = chude.Machude,

                Tenchude = chude.Tenchude,

               
            };
            _context.Chudes.Add(cd);
            await _context.SaveChangesAsync();
        }


    }
}
