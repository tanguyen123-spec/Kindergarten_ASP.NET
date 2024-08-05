using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiphiphuController : ControllerBase
    {
        private readonly IChiphiphuservice _chiphiphuService;

        public ChiphiphuController(IChiphiphuservice chiphiphuService)
        {
            _chiphiphuService = chiphiphuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chiphiphu>>> GetAll()
        {
            var chiphiphus = await _chiphiphuService.GetAll();
            return Ok(chiphiphus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chiphiphu>> GetById(string id)
        {
            var chiphiphu = await _chiphiphuService.GetById(id);
            if (chiphiphu == null)
            {
                return NotFound();
            }
            return Ok(chiphiphu);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Chiphiphu entity)
        {
            try
            {
                await _chiphiphuService.Create(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("models")]
        public async Task<ActionResult> CreatebyModels([FromBody] Chiphiphumodel chiphiphu)
        {
            try
            {
                await _chiphiphuService.CreatebyModels(chiphiphu);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Chiphiphu entity)
        {
            try
            {
                await _chiphiphuService.Update(id, entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _chiphiphuService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("hocvien-chiphiPHU/{childResumeId}")]
        public async Task<IActionResult> GetByChildresumeId(string childResumeId)
        {
            var chiphiphu = await _chiphiphuService.GetByChildResumeId(childResumeId);
            if (chiphiphu == null)
            {
                return NotFound();
            }
            return Ok(chiphiphu);
        }
        [HttpDelete("delete-by-childresumeid/{childResumeId}")]
        public async Task<IActionResult> DeleteByChildResumeId(string childResumeId)
        {
            try
            {
                await _chiphiphuService.DeleteByChildResumeId(childResumeId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
