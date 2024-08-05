using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Doantotnghiep_62131842.Services
{

    public interface ILopService
    {
        Task<IEnumerable<Lop>> GetAll();
        Task<Lop> GetById(string id);
        Task Create(Lop entity);
        Task CreatebyModels(LopModel lop);
        Task Update(string id, Lop entity);
        Task Delete(string id);
        Task<IEnumerable<ClassId_ClassModel>> GetAllDisplay(string namhoc, string classtypeId);



    }
    public class LopService : ILopService
    {
        private readonly IRepository<Lop> _repository;
        private readonly MamnonProjectContext _context;
        public LopService(IRepository<Lop> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Lop entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Lop>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Lop> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Lop entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(LopModel lop)
        {
            var l = new Lop
            {


                ClassId = lop.ClassId,
                ClasstypeId = lop.ClasstypeId,
                NameClass = lop.NameClass,
                Siso = lop.Siso,
                Namhoc = lop.Namhoc,


            };
            _context.Lops.Add(l);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ClassId_ClassModel>> GetAllDisplay(string namhoc, string classtypeId)
        {
            var classes = await (from l in _context.Lops
                                 join ll in _context.Loailops on l.ClasstypeId equals ll.ClasstypeId
                                 where l.Namhoc == namhoc && ll.ClasstypeId == classtypeId
                                 select new ClassId_ClassModel
                                 {
                                     ClassId = l.ClassId,
                                    
                                 }).ToListAsync();

            return classes;
        }
    }
}
