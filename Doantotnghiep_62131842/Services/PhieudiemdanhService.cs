using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
  
    public interface IPhieudiemdanhService
    {
        Task<IEnumerable<Phieudiemdanh>> GetAll();
        Task<Phieudiemdanh> GetById(string id);
        Task Create(Phieudiemdanh entity);
        Task CreatebyModels(PhieudiemdanhModel phieudiemdanh);
        Task Update(string id, Phieudiemdanh entity);
        Task Delete(string id);
        Task<int> GetTotalDiemDanhByChildResumeId(string childResumeId);
        Task DeleteByChildResumeId(string childResumeId);

    }
    public class PhieudiemdanhService : IPhieudiemdanhService
    {
        private readonly IRepository<Phieudiemdanh> _repository;
        private readonly MamnonProjectContext _context;
        public PhieudiemdanhService(IRepository<Phieudiemdanh> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Phieudiemdanh entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Phieudiemdanh>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Phieudiemdanh> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Phieudiemdanh entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(PhieudiemdanhModel phieudiemdanh)
        {
            var pdd = new Phieudiemdanh
            {


                DiemdanhId = phieudiemdanh.DiemdanhId,
                ChildResumeId = phieudiemdanh.ChildResumeId,
                Ngayhoc = phieudiemdanh.Ngayhoc,
                Namhoc = phieudiemdanh.Namhoc,
                thang_namhoc=phieudiemdanh.thang_namhoc

            };
            _context.Phieudiemdanhs.Add(pdd);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalDiemDanhByChildResumeId(string childResumeId)
        {
            return await _context.Phieudiemdanhs.CountAsync(pdd => pdd.ChildResumeId == childResumeId);
        }
        public async Task DeleteByChildResumeId(string childResumeId)
        {
            var phieuDiemDanhs = await _context.Phieudiemdanhs.Where(pdd => pdd.ChildResumeId == childResumeId).ToListAsync();

            _context.Phieudiemdanhs.RemoveRange(phieuDiemDanhs);
            await _context.SaveChangesAsync();
        }
    }
}
