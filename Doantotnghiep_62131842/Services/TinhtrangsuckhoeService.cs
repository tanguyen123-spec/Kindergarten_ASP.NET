using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
 
    public interface ITinhtrangsuckhoeService
    {
        Task<IEnumerable<Tinhtrangsuckhoe>> GetAll();
        Task<Tinhtrangsuckhoe> GetById(string id);
        Task Create(Tinhtrangsuckhoe entity);
        Task CreatebyModels(TinhtrangsuckhoeModel tinhtrangsuckhoe);
        Task Update(string id, Tinhtrangsuckhoe entity);
        Task Delete(string id);

    }
    public class TinhtrangsuckhoeService : ITinhtrangsuckhoeService
    {
        private readonly IRepository<Tinhtrangsuckhoe> _repository;
        private readonly MamnonProjectContext _context;
        public TinhtrangsuckhoeService(IRepository<Tinhtrangsuckhoe> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Tinhtrangsuckhoe entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Tinhtrangsuckhoe>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Tinhtrangsuckhoe> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Tinhtrangsuckhoe entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(TinhtrangsuckhoeModel tinhtrangsuckhoe)
        {
            var ttsk = new Tinhtrangsuckhoe
            {


                TtskId = tinhtrangsuckhoe.TtskId,
                ChildResumeId = tinhtrangsuckhoe.ChildResumeId,
                Magiaovien = tinhtrangsuckhoe.Magiaovien,
                Ngaykiemtra = tinhtrangsuckhoe.Ngaykiemtra,
                Nhietdo = tinhtrangsuckhoe.Nhietdo,
                Trangthaian = tinhtrangsuckhoe.Trangthaian,
                Trangthaingu = tinhtrangsuckhoe.Trangthaingu,
                Thaidohochanh = tinhtrangsuckhoe.Thaidohochanh,



            };
            _context.Tinhtrangsuckhoes.Add(ttsk);
            await _context.SaveChangesAsync();
        }
     
    }
}
