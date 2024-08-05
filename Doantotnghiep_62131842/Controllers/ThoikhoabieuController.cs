using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThoikhoabieuController : ControllerBase
    {
        private readonly IThoikhoabieuService _thoikhoabieuService;

        public ThoikhoabieuController(IThoikhoabieuService thoikhoabieuService)
        {
            _thoikhoabieuService = thoikhoabieuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thoikhoabieu>>> GetAll()
        {
            var thoikhoabieuList = await _thoikhoabieuService.GetAll();
            return Ok(thoikhoabieuList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Thoikhoabieu>> GetById(string id)
        {
            var thoikhoabieu = await _thoikhoabieuService.GetById(id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }

            return Ok(thoikhoabieu);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Thoikhoabieu thoikhoabieu)
        {
            await _thoikhoabieuService.Create(thoikhoabieu);
            return CreatedAtAction(nameof(GetById), new { id = thoikhoabieu.Matkb }, thoikhoabieu);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Thoikhoabieu thoikhoabieu)
        {
            await _thoikhoabieuService.Update(id, thoikhoabieu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _thoikhoabieuService.Delete(id);
            return NoContent();
        }

        [HttpPost("createbymodels")]
        public async Task<ActionResult> CreateByModels([FromBody] ThoikhoabieuModel thoikhoabieu)
        {
            await _thoikhoabieuService.CreatebyModels(thoikhoabieu);
            return CreatedAtAction(nameof(GetById), new { id = thoikhoabieu.Matkb }, thoikhoabieu);
        }
    }
}
