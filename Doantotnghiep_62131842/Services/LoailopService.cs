using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
   
    public interface ILoailopService
    {
        Task<IEnumerable<Loailop>> GetAll();
        Task<Loailop> GetById(string id);
        Task Create(Loailop entity);
        Task CreatebyModels(LoailopModel loailop);
        Task Update(string id, Loailop entity);
        Task Delete(string id);

    }
    public class LoailopService : ILoailopService
    {
        private readonly IRepository<Loailop> _repository;
        private readonly MamnonProjectContext _context;
        public LoailopService(IRepository<Loailop> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Loailop entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Loailop>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Loailop> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Loailop entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(LoailopModel loailop)
        {
            var ll = new Loailop
            {


                ClasstypeId = loailop.ClasstypeId,
                NameClasstype = loailop.NameClasstype,


            };
            _context.Loailops.Add(ll);
            await _context.SaveChangesAsync();
        }
      
       

    }
}
