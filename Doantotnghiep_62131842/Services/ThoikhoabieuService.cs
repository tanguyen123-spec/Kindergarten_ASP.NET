using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
   
    public interface IThoikhoabieuService
    {
        Task<IEnumerable<Thoikhoabieu>> GetAll();
        Task<Thoikhoabieu> GetById(string id);
        Task Create(Thoikhoabieu entity);
        Task CreatebyModels(ThoikhoabieuModel thoikhoabieu);
        Task Update(string id, Thoikhoabieu entity);
        Task Delete(string id);

    }
    public class ThoikhoabieuService : IThoikhoabieuService
    {
        private readonly IRepository<Thoikhoabieu> _repository;
        private readonly MamnonProjectContext _context;
        public ThoikhoabieuService(IRepository<Thoikhoabieu> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Thoikhoabieu entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Thoikhoabieu>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Thoikhoabieu> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Thoikhoabieu entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(ThoikhoabieuModel thoikhoabieu)
        {
            var tkb = new Thoikhoabieu
            {


                Matkb = thoikhoabieu.Matkb,
                ClassId = thoikhoabieu.ClassId,
                Magiaovien = thoikhoabieu.Magiaovien,
                Ngaybatdau = thoikhoabieu.Ngaybatdau,
                Ngayketthuc = thoikhoabieu.Ngayketthuc,
               


            };
            _context.Thoikhoabieus.Add(tkb);
            await _context.SaveChangesAsync();
        }
      
    }
}
