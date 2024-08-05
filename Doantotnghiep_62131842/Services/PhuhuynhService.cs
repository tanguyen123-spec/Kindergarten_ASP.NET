using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
  
    public interface IPhuhuynhService
    {
        Task<IEnumerable<Phuhuynh>> GetAll();
        Task<Phuhuynh> GetById(string id);
        Task Create(Phuhuynh entity);
        Task CreatebyModels(PhuhuynhModel phuhuynh);
        Task Update(string id, Phuhuynh entity);
        Task Delete(string id);
     
    }
    public class PhuhuynhService : IPhuhuynhService
    {
        private readonly IRepository<Phuhuynh> _repository;
        private readonly MamnonProjectContext _context;
        public PhuhuynhService(IRepository<Phuhuynh> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Phuhuynh entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Phuhuynh>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Phuhuynh> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Phuhuynh entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(PhuhuynhModel phuhuynh)
        {
            var ph = new Phuhuynh
            {


                ParentResumeId = phuhuynh.ParentResumeId,
                NameP = phuhuynh.NameP,
                DateOfBirth = phuhuynh.DateOfBirth,
                Phone1 = phuhuynh.Phone1,
                Phone2 = phuhuynh.Phone2,
                NameP2 = phuhuynh.NameP2,
                Diachi = phuhuynh.Diachi,
                Gender = phuhuynh.Gender,
                JobParent = phuhuynh.JobParent,
                NumberOfChildren = phuhuynh.NumberOfChildren,
                ImageUrl = phuhuynh.ImageUrl,
               


            };
            _context.Phuhuynhs.Add(ph);
            await _context.SaveChangesAsync();
        }

       


    }
}
