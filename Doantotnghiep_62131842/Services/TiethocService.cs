using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using System.Linq;
namespace Doantotnghiep_62131842.Services
{

    public interface ITiethocService
    {
        Task<IEnumerable<Tiethoc>> GetAll();
        Task<Tiethoc> GetById(string id);
        Task Create(Tiethoc entity);
        Task CreatebyModels(TiethocModel tiethoc);
        Task Update(string id, Tiethoc entity);
        Task Delete(string id);
        Task<IEnumerable<Tiethoc>> GetByMatkb(string matkb);

    }
    public class TiethocService : ITiethocService
    {
        private readonly IRepository<Tiethoc> _repository;
        private readonly MamnonProjectContext _context;
        public TiethocService(IRepository<Tiethoc> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Tiethoc entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Tiethoc>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Tiethoc> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Tiethoc entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(TiethocModel tiethoc)
        {
            var th = new Tiethoc
            {


                Tiethocid = tiethoc.Tiethocid,
                Matkb = tiethoc.Matkb,
                Thoigianbatdauhoc = tiethoc.Thoigianbatdauhoc,
                Thoigianketthuchoc = tiethoc.Thoigianketthuchoc,
                Ngayhoc = tiethoc.Ngayhoc,
                Tieuthoc = tiethoc.Tieuthoc,



            };
            _context.Tiethocs.Add(th);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Tiethoc>> GetByMatkb(string matkb)
        {
            var tiethocs = await _repository.GetAll();
            return tiethocs.Where(t => t.Matkb == matkb);
        }

    }
}
