using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChudeController : ControllerBase
    {
        private readonly IChudeService _chudeService;

        public ChudeController(IChudeService chudeService)
        {
            _chudeService = chudeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChude()
        {
            var chudes = await _chudeService.GetAll();
            return Ok(chudes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChudeById(string id)
        {
            var chude = await _chudeService.GetById(id);
            if (chude == null)
            {
                return NotFound();
            }
            return Ok(chude);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChude([FromBody] ChudeModel chude)
        {
            await _chudeService.CreatebyModels(chude);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChude(string id, [FromBody] Chude chude)
        {
            await _chudeService.Update(id, chude);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChude(string id)
        {
            await _chudeService.Delete(id);
            return Ok();
        }
    }
}
