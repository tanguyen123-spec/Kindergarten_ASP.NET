using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;

namespace Doantotnghiep_62131842.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task Create(User entity);
        Task CreatebyModels(UserModel user);
        Task Update(string id, User entity);
        Task Delete(string id);

    }
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly MamnonProjectContext _context;
        public UserService(IRepository<User> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(User entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, User entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(UserModel user)
        {
            var U = new User
            {


                UserId = user.UserId,
                Username = user.Username,
                Mail = user.Mail,
                RoleId = user.RoleId,
                Password = user.Password,
                Magiaovien = user.Magiaovien,
                ParentResumeId = user.ParentResumeId,
                



            };
            _context.Users.Add(U);
            await _context.SaveChangesAsync();
        }
        
    }
}
