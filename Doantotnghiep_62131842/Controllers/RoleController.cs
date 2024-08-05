using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(string id)
        {
            var role = await _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(Role role)
        {
            await _roleService.Create(role);
            return CreatedAtAction(nameof(GetById), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, Role role)
        {
            await _roleService.Update(id, role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _roleService.Delete(id);
            return NoContent();
        }
        [HttpPost("create-by-models")]
        public async Task<ActionResult> CreateByModels([FromBody] RoleModel ph)
        {

            await _roleService.CreatebyModels(ph);
            return Ok();


        }
    }
}

