using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaigiaovienController : ControllerBase
    {
        private readonly ILoaigiaovienService _loaigiaovienService;

        public LoaigiaovienController(ILoaigiaovienService loaigiaovienService)
        {
            _loaigiaovienService = loaigiaovienService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loaigiaovien>>> GetAll()
        {
            var loaigiaoviens = await _loaigiaovienService.GetAll();
            return Ok(loaigiaoviens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loaigiaovien>> GetById(string id)
        {
            var loaigiaovien = await _loaigiaovienService.GetById(id);
            if (loaigiaovien == null)
            {
                return NotFound();
            }
            return Ok(loaigiaovien);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Loaigiaovien loaigiaovien)
        {
            await _loaigiaovienService.Create(loaigiaovien);
            return CreatedAtAction(nameof(GetById), new { id = loaigiaovien.Maloaigiaovien }, loaigiaovien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Loaigiaovien loaigiaovien)
        {
            await _loaigiaovienService.Update(id, loaigiaovien);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _loaigiaovienService.Delete(id);
            return NoContent();
        }
        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(LoaigiaovienModel giaovien)
        {
            await _loaigiaovienService.CreatebyModels(giaovien);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            return Ok();
        }
    }
}
