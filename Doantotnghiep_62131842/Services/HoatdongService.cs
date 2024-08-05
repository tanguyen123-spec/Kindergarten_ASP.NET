using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IHoatDongsService
    {
        Task<IEnumerable<Hoatdong>> GetAll();
        Task<Hoatdong> GetById(string id);
        Task Create(Hoatdong entity);
        Task CreatebyModels(HoatdongModel hoatdongModel);
        Task Update(string id, Hoatdong entity);
        Task Delete(string id);

    }
    public class HoatDongsService : IHoatDongsService
    {
        private readonly IRepository<Hoatdong> _repository;
        private readonly MamnonProjectContext _context;
        public HoatDongsService(IRepository<Hoatdong> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Hoatdong entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Hoatdong>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Hoatdong> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Hoatdong entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(HoatdongModel hoatdong)
        {
            var hd = new Hoatdong
            {

                Mahoatdong = hoatdong.Mahoatdong,
                Tenhoatdong = hoatdong.Tenhoatdong,
                Chiphi = hoatdong.Chiphi,

            };
            _context.Hoatdongs.Add(hd);
            await _context.SaveChangesAsync();
        }


    }
}
