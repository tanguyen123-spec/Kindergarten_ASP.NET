using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IGiaoVienService
    {
        Task<IEnumerable<Giaovien>> GetAll();
        Task<Giaovien> GetById(string id);
        Task Create(Giaovien entity);
        Task CreatebyModels(GiaovienModel giaovien);
        Task Update(string id, Giaovien entity);
        Task Delete(string id);

    }
    public class GiaoVienService : IGiaoVienService
    {
        private readonly IRepository<Giaovien> _repository;
        private readonly MamnonProjectContext _context;
        public GiaoVienService(IRepository<Giaovien> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Giaovien entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Giaovien>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Giaovien> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Giaovien entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(GiaovienModel giaovien)
        {
            var gv = new Giaovien
            {

              
             Magiaovien = giaovien.Magiaovien,
             Maloaigiaovien = giaovien.Maloaigiaovien,
             Tengiaovien = giaovien.Tengiaovien,
             Ngaysinh = giaovien.Ngaysinh,
             Diachi = giaovien.Diachi,
             Sodienthoai = giaovien.Sodienthoai,
             ImageUrl = giaovien.ImageUrl,



            };
            _context.Giaoviens.Add(gv);
            await _context.SaveChangesAsync();
        }


    }
}
