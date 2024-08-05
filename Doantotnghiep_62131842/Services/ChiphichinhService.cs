using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
    public interface IChiphichinhService
    {
        Task<IEnumerable<Chiphichinh>> GetAll();
        Task<Chiphichinh> GetById(string id);
        Task Create(Chiphichinh entity);
        Task Update(string id, Chiphichinh entity);
        Task Delete(string id);
        Task CreatebyModels(Chiphichinhmodel chiphichinhmodel);
        Task CreateChiphichinhByChildResumeId(string ChildResumeId, string thang_namhoc);
        Task CreateChiphichinhByThangNamhoc(string thang_namhoc);
        Task<IEnumerable<Chiphichinh>> GetByChildResumeId(string childResumeId);
        Task DeleteByChildResumeId(string childResumeId);
    }
    public class ChiphichinhService: IChiphichinhService
    {

        private readonly IRepository<Chiphichinh> _repository;
        private readonly MamnonProjectContext _context;
        public ChiphichinhService(IRepository<Chiphichinh> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Chiphichinh entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Chiphichinh>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Chiphichinh> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Chiphichinh entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(Chiphichinhmodel chiphichinhmodel)
        {
            var cpc = new Chiphichinh
            {

                Machiphichinh = chiphichinhmodel.Machiphichinh,
                Mahoatdong = chiphichinhmodel.Mahoatdong,
                ChildResumeId= chiphichinhmodel.ChildResumeId,
              


            };
            _context.Chiphichinhs.Add(cpc);
            await _context.SaveChangesAsync();
        }
        public async Task CreateChiphichinhByChildResumeId(string ChildResumeId, string thang_namhoc)
        {
            var mahoatdongs = await _context.Hoatdongchinhs
                .Select(hd => hd.Mahoatdong)
                .ToListAsync();

            foreach (var mahoatdong in mahoatdongs)
            {
                var guid = Guid.NewGuid().ToString();
                var machiphichinh = guid.Substring(0, Math.Min(guid.Length, 10));

                var chiphichinh = new Chiphichinh
                {
                    Machiphichinh = machiphichinh,
                    Mahoatdong = mahoatdong,
                    thang_namhoc = thang_namhoc,
                    ChildResumeId = ChildResumeId
                };

                _context.Chiphichinhs.Add(chiphichinh);
            }

            await _context.SaveChangesAsync();
        }
        public async Task CreateChiphichinhByThangNamhoc(string thang_namhoc)
        {
            var childResumes = await _context.Hocviens.ToListAsync();
            var mahoatdongs = await _context.Hoatdongchinhs
                .Select(hd => hd.Mahoatdong)
                .ToListAsync();

            foreach (var childResume in childResumes)
            {
                foreach (var mahoatdong in mahoatdongs)
                {
                    var guid = Guid.NewGuid().ToString();
                    var machiphichinh = guid.Substring(0, Math.Min(guid.Length, 10));

                    var chiphichinh = new Chiphichinh
                    {
                        Machiphichinh = machiphichinh,
                        Mahoatdong = mahoatdong,
                        thang_namhoc = thang_namhoc,
                        ChildResumeId = childResume.ChildResumeId
                    };

                    _context.Chiphichinhs.Add(chiphichinh);
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Chiphichinh>> GetByChildResumeId(string childResumeId)
        {
            return await _context.Chiphichinhs.Where(c => c.ChildResumeId == childResumeId).ToListAsync();
        }
        public async Task DeleteByChildResumeId(string childResumeId)
        {
            var chiphichinhs = await _context.Chiphichinhs
                .Where(c => c.ChildResumeId == childResumeId)
                .ToListAsync();

            if (chiphichinhs.Count > 0)
            {
                _context.Chiphichinhs.RemoveRange(chiphichinhs);
                await _context.SaveChangesAsync();
            }
        }
    }
}
