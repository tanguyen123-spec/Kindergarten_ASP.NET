using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoailopController : ControllerBase
    {
        private readonly ILoailopService _loailopService;

        public LoailopController(ILoailopService loailopService)
        {
            _loailopService = loailopService;
        }

        // GET: api/Loailop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loailop>>> GetAll()
        {
            var loailops = await _loailopService.GetAll();
            return Ok(loailops);
        }

        // GET: api/Loailop/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Loailop>> GetById(string id)
        {
            var loailop = await _loailopService.GetById(id);
            if (loailop == null)
            {
                return NotFound();
            }
            return Ok(loailop);
        }

        // POST: api/Loailop
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Loailop entity)
        {
            await _loailopService.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.ClasstypeId }, entity);
        }

        // PUT: api/Loailop/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Loailop entity)
        {
            try
            {
                await _loailopService.Update(id, entity);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Loailop/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _loailopService.Delete(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Loailop/CreatebyModels
        [HttpPost("CreatebyModels")]
        public async Task<ActionResult> CreatebyModels([FromBody] LoailopModel loailop)
        {
            await _loailopService.CreatebyModels(loailop);
            return Ok();
        }
    }
}
