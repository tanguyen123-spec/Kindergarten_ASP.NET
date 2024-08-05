using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonnhaphocController : ControllerBase
    {
        private readonly IDonnhaphocService _donnhaphocService;

        public DonnhaphocController(IDonnhaphocService donnhaphocService)
        {
            _donnhaphocService = donnhaphocService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donnhaphoc>>> GetAll()
        {
            var donnhaphocs = await _donnhaphocService.GetAll();
            return Ok(donnhaphocs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Donnhaphoc>> GetById(string id)
        {
            var donnhaphoc = await _donnhaphocService.GetById(id);
            if (donnhaphoc == null)
            {
                return NotFound();
            }
            return Ok(donnhaphoc);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Donnhaphoc entity)
        {
            await _donnhaphocService.Create(entity);
            return Ok();
        }

        [HttpPost("models")]
        public async Task<IActionResult> CreateByModels(DonnhaphocModel donnhaphoc)
        {
            await _donnhaphocService.CreatebyModels(donnhaphoc);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Donnhaphoc entity)
        {
            await _donnhaphocService.Update(id, entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _donnhaphocService.Delete(id);
            return Ok();
        }
    }
}
