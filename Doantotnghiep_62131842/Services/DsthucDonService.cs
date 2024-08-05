using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
    
    public interface IDsthucDonService
    {
        Task<IEnumerable<DsthucDon>> GetAll();
        Task<DsthucDon> GetById(string id);
        Task Create(DsthucDon entity);
        Task CreatebyModels(DsthucDonModel dsthucDon);
        Task Update(string id, DsthucDonModel dsthucDonModel);
        Task Delete(string id);
       
    }
    public class DsthucDonService : IDsthucDonService
    {
        private readonly IRepository<DsthucDon> _repository;
        private readonly MamnonProjectContext _context;
        public DsthucDonService(IRepository<DsthucDon> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(DsthucDon entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<DsthucDon>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<DsthucDon> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, DsthucDonModel dsthucDonModel)
        {
            var existingDsthucDon = await _repository.GetById(id);
            if (existingDsthucDon == null)
            {
                // Xử lý khi không tìm thấy đối tượng cần cập nhật
                return;
            }

            // Cập nhật các thuộc tính của đối tượng existingDsthucDon từ dsthucDonModel
            existingDsthucDon.MenuId = dsthucDonModel.MenuId;
            existingDsthucDon.Ngaybatdau = dsthucDonModel.Ngaybatdau;
            existingDsthucDon.Ngayketthuc = dsthucDonModel.Ngayketthuc;

            await _repository.Update(id, existingDsthucDon);
        }
        public async Task CreatebyModels(DsthucDonModel dsthucDon)
        {
            var dstd = new DsthucDon
            {


                MenuId = dsthucDon.MenuId,
                Ngaybatdau = dsthucDon.Ngaybatdau,
                Ngayketthuc = dsthucDon.Ngayketthuc,
            


            };
            _context.DsthucDons.Add(dstd);
            await _context.SaveChangesAsync();
        }
      

    }
}
