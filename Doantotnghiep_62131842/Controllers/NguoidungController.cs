using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoidungController : ControllerBase
    {
        private readonly IUserService _userService;

        public NguoidungController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            await _userService.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, User user)
        {
            await _userService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(UserModel user)
        {
            await _userService.CreatebyModels(user);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            return Ok();
        }
    }
}
