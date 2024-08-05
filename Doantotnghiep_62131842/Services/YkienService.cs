using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IYkienService
    {
        Task<IEnumerable<Ykien>> GetAll();
        Task<Ykien> GetById(string id);
        Task Create(Ykien entity);
        Task CreatebyModels(YkienModel user);
        Task Update(string id, Ykien entity);
        Task Delete(string id);

    }
    public class YkienService : IYkienService
    {
        private readonly IRepository<Ykien> _repository;
        private readonly MamnonProjectContext _context;
        public YkienService(IRepository<Ykien> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Ykien entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Ykien>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Ykien> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Ykien entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(YkienModel ykien)
        {
            var yk = new Ykien
            {


                OpinionId = ykien.OpinionId,
                Machude = ykien.Machude,
                ParentResumeId = ykien.ParentResumeId,
                NoteOpinion = ykien.NoteOpinion,
                Giaiphap = ykien.Giaiphap,
              




            };
            _context.Ykiens.Add(yk);
            await _context.SaveChangesAsync();
        }
      

    }
}
