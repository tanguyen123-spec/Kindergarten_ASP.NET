using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieubengoanController : ControllerBase
    {
        private readonly IPhieubengoanService _phieubengoanService;

        public PhieubengoanController(IPhieubengoanService phieubengoanService)
        {
            _phieubengoanService = phieubengoanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var phieubengoans = await _phieubengoanService.GetAll();
                return Ok(phieubengoans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var phieubengoan = await _phieubengoanService.GetById(id);
                if (phieubengoan == null)
                    return NotFound();

                return Ok(phieubengoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Phieubengoan phieubengoan)
        {
            try
            {
                await _phieubengoanService.Create(phieubengoan);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Phieubengoan phieubengoan)
        {
            try
            {
                await _phieubengoanService.Update(id, phieubengoan);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _phieubengoanService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createbymodels")]
        public async Task<IActionResult> CreateByModels([FromBody] PhieubengoanModel phieubengoan)
        {
            try
            {
                await _phieubengoanService.CreatebyModels(phieubengoan);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
