using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IHoatdongchinhService
    {
        Task<IEnumerable<Hoatdongchinh>> GetAll();
        Task<Hoatdongchinh> GetById(string id);
        Task Create(Hoatdongchinh entity);
        Task Update(string id, Hoatdongchinh entity);
        Task Delete(string id);

    }
    public class HoatdongchinhService: IHoatdongchinhService
    {
        private readonly IRepository<Hoatdongchinh> _repository;
        private readonly MamnonProjectContext _context;
        public HoatdongchinhService(IRepository<Hoatdongchinh> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Hoatdongchinh entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Hoatdongchinh>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Hoatdongchinh> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Hoatdongchinh entity)
        {
            await _repository.Update(id, entity);
        }
       


    }

}

