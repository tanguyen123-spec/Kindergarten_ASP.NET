using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YkienController : ControllerBase
    {
        private readonly IYkienService _ykienService;

        public YkienController(IYkienService ykienService)
        {
            _ykienService = ykienService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllYkien()
        {
            var ykiens = await _ykienService.GetAll();
            return Ok(ykiens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetYkienById(string id)
        {
            var ykien = await _ykienService.GetById(id);
            if (ykien == null)
            {
                return NotFound();
            }
            return Ok(ykien);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYkien([FromBody] YkienModel ykien)
        {
            await _ykienService.CreatebyModels(ykien);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYkien(string id, [FromBody] Ykien ykien)
        {
            await _ykienService.Update(id, ykien);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYkien(string id)
        {
            await _ykienService.Delete(id);
            return Ok();
        }
    }
}
