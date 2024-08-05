using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{

    
    public interface IPhieubengoanService
    {
        Task<IEnumerable<Phieubengoan>> GetAll();
        Task<Phieubengoan> GetById(string id);
        Task Create(Phieubengoan entity);
        Task CreatebyModels(PhieubengoanModel phieubengoan);
        Task Update(string id, Phieubengoan entity);
        Task Delete(string id);

    }
    public class PhieubengoanService : IPhieubengoanService
    {
        private readonly IRepository<Phieubengoan> _repository;
        private readonly MamnonProjectContext _context;
        public PhieubengoanService(IRepository<Phieubengoan> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Phieubengoan entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Phieubengoan>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Phieubengoan> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Phieubengoan entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(PhieubengoanModel phieubengoan)
        {
            var pbn = new Phieubengoan
            {


                PhbnId = phieubengoan.PhbnId,
                ChildResumeId = phieubengoan.ChildResumeId,
                Magiaovien = phieubengoan.Magiaovien,
                Hanhvi = phieubengoan.Hanhvi,
                Thaido = phieubengoan.Thaido,
                Thanhtich = phieubengoan.Thanhtich,


            };
            _context.Phieubengoans.Add(pbn);
            await _context.SaveChangesAsync();
        }
      


    }
}
