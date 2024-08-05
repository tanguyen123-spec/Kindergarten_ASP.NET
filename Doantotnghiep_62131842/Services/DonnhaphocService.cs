using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
  
    public interface IDonnhaphocService
    {
        Task<IEnumerable<Donnhaphoc>> GetAll();
        Task<Donnhaphoc> GetById(string id);
        Task Create(Donnhaphoc entity);
        Task CreatebyModels(DonnhaphocModel donnhaphoc);
        Task Update(string id, Donnhaphoc entity);
        Task Delete(string id);

    }
    public class DonnhaphocService : IDonnhaphocService
    {
        private readonly IRepository<Donnhaphoc> _repository;
        private readonly MamnonProjectContext _context;
        public DonnhaphocService(IRepository<Donnhaphoc> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Donnhaphoc entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Donnhaphoc>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Donnhaphoc> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Donnhaphoc entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(DonnhaphocModel donnhaphoc)
        {
            var dnh = new Donnhaphoc
            {

                AfaId = donnhaphoc.AfaId,
                Lophocmongmuon = donnhaphoc.Lophocmongmuon,
                Namhoc = donnhaphoc.Namhoc,
                Batdauhoc = donnhaphoc.Batdauhoc,
                Status = donnhaphoc.Status,
                Ngaytaodon = donnhaphoc.Ngaytaodon,
                SdtLienhe = donnhaphoc.SdtLienhe,
                Name = donnhaphoc.Name,
              

    };
            _context.Donnhaphocs.Add(dnh);
            await _context.SaveChangesAsync();
        
        }
     

    }
}
