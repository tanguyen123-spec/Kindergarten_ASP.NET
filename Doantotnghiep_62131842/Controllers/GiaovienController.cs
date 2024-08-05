using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaovienController : ControllerBase
    {
        private readonly IGiaoVienService _giaovienService;

        public GiaovienController(IGiaoVienService giaovienService)
        {
            _giaovienService = giaovienService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giaovien>>> GetAll()
        {
            var giaoviens = await _giaovienService.GetAll();
            return Ok(giaoviens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Giaovien>> GetById(string id)
        {
            var giaovien = await _giaovienService.GetById(id);
            if (giaovien == null)
            {
                return NotFound();
            }
            return Ok(giaovien);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Giaovien giaovien)
        {
            await _giaovienService.Create(giaovien);
            return CreatedAtAction(nameof(GetById), new { id = giaovien.Magiaovien }, giaovien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Giaovien giaovien)
        {
            await _giaovienService.Update(id, giaovien);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _giaovienService.Delete(id);
            return NoContent();
        }
        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(GiaovienModel giaovien)
        {
            await _giaovienService.CreatebyModels(giaovien);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            return Ok();
        }
    }
}

