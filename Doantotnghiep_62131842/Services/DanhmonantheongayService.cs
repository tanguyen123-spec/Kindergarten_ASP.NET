using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Doantotnghiep_62131842.Services
{
   
    public interface IDanhmonantheongayService
    {
        Task<IEnumerable<Danhmonantheongay>> GetAll();
        Task<Danhmonantheongay> GetById(string id);
        Task Create(Danhmonantheongay entity);
        Task CreatebyModels(DanhmonantheongayModel chude);
        Task Update(string id, Danhmonantheongay entity);
        Task Delete(string id);
        Task<List<DanhmonantheongayModel>> GetMenuIdByCurrentDate();
        Task<List<DsthucDon>> GetMenuIdByCurrentDateTd();
    }
    public class DanhmonantheongayService : IDanhmonantheongayService
    {
        private readonly IRepository<Danhmonantheongay> _repository;
        private readonly MamnonProjectContext _context;
        public DanhmonantheongayService(IRepository<Danhmonantheongay> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Danhmonantheongay entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Danhmonantheongay>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Danhmonantheongay> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Danhmonantheongay entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(DanhmonantheongayModel danhmonantheongay)
        {
            var dsma = new Danhmonantheongay
            {
           
              Malichngay = danhmonantheongay.Malichngay,
              MenuId = danhmonantheongay.MenuId,
              Ngay = danhmonantheongay.Ngay,
              Buoisang = danhmonantheongay.Buoisang,
              Buoitrua = danhmonantheongay.Buoitrua,
              Buoichieu = danhmonantheongay.Buoichieu,
              Trangmieng = danhmonantheongay.Trangmieng,


            };
            _context.Danhmonantheongays.Add(dsma);
            await _context.SaveChangesAsync();
        }
        public async Task<List<DanhmonantheongayModel>> GetMenuIdByCurrentDate()
        {
            var currentDate = DateTime.Now.Date;

            var dsthucDon = await _context.DsthucDons.FirstOrDefaultAsync(d => d.Ngaybatdau.HasValue && d.Ngaybatdau.Value.Date <= currentDate && d.Ngayketthuc.HasValue && d.Ngayketthuc.Value.Date >= currentDate);

            if (dsthucDon == null)
            {
                return null; // Hoặc bạn có thể ném ra một exception hoặc trả về giá trị mặc định tùy theo yêu cầu của bạn
            }

            var menuId = dsthucDon.MenuId;

            var danhmonantheongays = await _context.Danhmonantheongays
     .Where(d => d.MenuId == menuId && d.Ngay >= dsthucDon.Ngaybatdau && d.Ngay <= dsthucDon.Ngayketthuc)
     .ToListAsync();

            return danhmonantheongays.Select(d => new DanhmonantheongayModel
            {
                Malichngay = d.Malichngay,
                Ngay = d.Ngay,
                Buoisang = d.Buoisang,
                Buoitrua = d.Buoitrua,
                Buoichieu = d.Buoichieu,
                Trangmieng = d.Trangmieng
            }).ToList();
        }
        public async Task<List<DsthucDon>> GetMenuIdByCurrentDateTd()
        {
            var currentDate = DateTime.Now.Date;

            var dsthucDon = await _context.DsthucDons
                .Where(d => d.Ngaybatdau.HasValue && d.Ngaybatdau.Value.Date <= currentDate && d.Ngayketthuc.HasValue && d.Ngayketthuc.Value.Date >= currentDate)
                .ToListAsync();

            return dsthucDon;
        }

    }
}
