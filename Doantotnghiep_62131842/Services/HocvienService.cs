using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
    public interface IHocVienService
    {
        Task<IEnumerable<Hocvien>> GetAll();
        Task<Hocvien> GetById(string id);
        Task Create(Hocvien entity);
        Task CreatebyModels(HocvienModel hocvien);
        Task Update(string id, Hocvien entity);
        Task Delete(string id);
        Task UpdateImageUrl(string ChildResumeId, string imageUrl);
        Task<IEnumerable<Hocvien>> FindHocVienByClassId(string classId);
        Task UpdateClassId(string oldClassId, string newClassId);
        Task<decimal> CalculateTotalChiPhi();
    }
    public class HocVienService : IHocVienService
    {
        private readonly IRepository<Hocvien> _repository;
        private readonly MamnonProjectContext _context;
        public HocVienService(IRepository<Hocvien> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Hocvien entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Hocvien>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Hocvien> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Hocvien entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(HocvienModel hocvien)
        {
            var HV = new Hocvien
            {  

             ChildResumeId = hocvien.ChildResumeId, 
             ParentResumeId = hocvien.ParentResumeId,
             AfaId = hocvien.AfaId,
             ClassId = hocvien.ClassId,
             Name = hocvien.Name,
             Diachi = hocvien.Diachi,
             Gender = hocvien.Gender,
             MedicalHistory = hocvien.MedicalHistory,
             InformationDif = hocvien.InformationDif,
             CurrentHealthStatus = hocvien.CurrentHealthStatus,
             ImageUrl = hocvien.ImageUrl,

            };
            _context.Hocviens.Add(HV);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            var donNhapHoc = await _context.Donnhaphocs.FirstOrDefaultAsync(d => d.AfaId == hocvien.AfaId);
            if (donNhapHoc != null)
            {
                donNhapHoc.Status = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateImageUrl(string ChildResumeId, string imageUrl)
        {
            var hocvien = await _context.Hocviens.FirstOrDefaultAsync(p => p.ChildResumeId == ChildResumeId);
            if (hocvien != null)
            {
                hocvien.ImageUrl = imageUrl;
             
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Hocvien>> FindHocVienByClassId(string classId)
        {
            var hocViens = await _context.Hocviens.Where(hv => hv.ClassId == classId).ToListAsync();
            return hocViens;
        }
        public async Task UpdateClassId(string oldClassId, string newClassId)
        {
            var oldClass = await _context.Lops.FirstOrDefaultAsync(c => c.ClassId == oldClassId);
            var newClass = await _context.Lops.FirstOrDefaultAsync(c => c.ClassId == newClassId);

            if (oldClass == null)
            {
                throw new Exception("No class found with the specified oldClassId.");
            }

            if (newClass == null)
            {
                throw new Exception("No class found with the specified newClassId.");
            }

            var studentsToUpdate = await _context.Hocviens.Where(h => h.ClassId == oldClassId).ToListAsync();

            if (studentsToUpdate.Count == 0)
            {
                throw new Exception("No students found in the specified oldClass.");
            }

            if (oldClass.Siso > newClass.Siso)
            {
                throw new Exception("The new class cannot accommodate all the students from the oldClass.");
            }

            foreach (var student in studentsToUpdate)
            {
                student.ClassId = newClassId;
            }

           
        }
        public async Task<decimal> CalculateTotalChiPhi()
        {
            var hocviens = await _context.Hocviens.ToListAsync();
            decimal totalChiPhi = 0;

            foreach (var hocvien in hocviens)
            {
                totalChiPhi += hocvien.Chiphibandau;
            }

            return totalChiPhi;
        }

    }
}
