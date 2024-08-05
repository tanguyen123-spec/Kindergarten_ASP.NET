using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
   

    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(string id);
        Task Create(Role entity);
        Task CreatebyModels(RoleModel role);
        Task Update(string id, Role entity);
        Task Delete(string id);

    }
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;
        private readonly MamnonProjectContext _context;
        public RoleService(IRepository<Role> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Role entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Role> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Role entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(RoleModel Role)
        {
            var r = new Role
            {


                RoleId = Role.RoleId,
                Rolename = Role.Rolename,

            };
            _context.Roles.Add(r);
            await _context.SaveChangesAsync();
        }

    


    }
}
