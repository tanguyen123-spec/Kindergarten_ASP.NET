using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json; // Thêm directive này

namespace Doantotnghiep_62131842.Services
{
    public interface IBienlaiService
    {
        Task<IEnumerable<Bienlai>> GetAll();
        Task<Bienlai> GetById(string id);
        Task Create(Bienlai entity);
        Task CreateByModel(BienlaiModel bienlai);
        Task Update(string id, Bienlai entity);
        Task Delete(string id);
        Task<IEnumerable<ThongKeBienLai>> ThongKeTheoThangNamHoc();
    }

    public class BienlaiService : IBienlaiService
    {
        private readonly IRepository<Bienlai> _repository;
        private readonly MamnonProjectContext _context;

        public BienlaiService(IRepository<Bienlai> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Bienlai entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Bienlai>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Bienlai> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Bienlai entity)
        {
            await _repository.Update(id, entity);
        }

        public async Task CreateByModel(BienlaiModel bienlai)
        {
            var bl = new Bienlai
            {
                Mabienlai = bienlai.Mabienlai,
                ChildResumeId = bienlai.ChildResumeId,
                tongchiphiphaitra = bienlai.tongchiphiphaitra,
                trangthai = bienlai.trangthai,
                thang_namhoc=bienlai.thang_namhhoc
            };

            _context.Bienlais.Add(bl);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThongKeBienLai>> ThongKeTheoThangNamHoc()
        {
            var thongKeList = await _context.Bienlais
                .GroupBy(b => b.thang_namhoc)
                .Select(g => new ThongKeBienLai
                {
                    ThangNamHoc = g.Key,
                    TongChiPhi= g.Sum(b => b.tongchiphiphaitra)
                })
                .ToListAsync();

            return thongKeList;
        }
    }
}
