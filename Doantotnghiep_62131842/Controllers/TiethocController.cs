using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiethocController : ControllerBase
    {
        private readonly ITiethocService _tiethocService;

        public TiethocController(ITiethocService tiethocService)
        {
            _tiethocService = tiethocService;
        }

        // GET: api/Tiethoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiethoc>>> GetAll()
        {
            var tiethocs = await _tiethocService.GetAll();
            return Ok(tiethocs);
        }

        // GET: api/Tiethoc/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiethoc>> GetById(string id)
        {
            var tiethoc = await _tiethocService.GetById(id);
            if (tiethoc == null)
            {
                return NotFound();
            }
            return Ok(tiethoc);
        }

        // POST: api/Tiethoc
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tiethoc tiethoc)
        {
            await _tiethocService.Create(tiethoc);
            return CreatedAtAction(nameof(GetById), new { id = tiethoc.Tiethocid }, tiethoc);
        }

        // POST: api/Tiethoc/CreatebyModels
        [HttpPost("CreatebyModels")]
        public async Task<ActionResult> CreatebyModels([FromBody] TiethocModel tiethocModel)
        {
            try
            {
                await _tiethocService.CreatebyModels(tiethocModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Tiethoc/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Tiethoc tiethoc)
        {
            var existingTiethoc = await _tiethocService.GetById(id);
            if (existingTiethoc == null)
            {
                return NotFound();
            }
            await _tiethocService.Update(id, tiethoc);
            return NoContent();
        }

        // DELETE: api/Tiethoc/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingTiethoc = await _tiethocService.GetById(id);
            if (existingTiethoc == null)
            {
                return NotFound();
            }
            await _tiethocService.Delete(id);
            return NoContent();
        }
        // GET: api/Tiethoc/ByMatkb/{matkb}
        [HttpGet("ByMatkb/{matkb}")]
        public async Task<ActionResult<IEnumerable<Tiethoc>>> GetByMatkb(string matkb)
        {
            var tiethocs = await _tiethocService.GetByMatkb(matkb);
            return Ok(tiethocs);
        }
    }
}

