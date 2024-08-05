using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiphichinhController : ControllerBase
    {
        private readonly IChiphichinhService _chiphichinhService;

        public ChiphichinhController(IChiphichinhService chiphichinhService)
        {
            _chiphichinhService = chiphichinhService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chiphichinhs = await _chiphichinhService.GetAll();
            return Ok(chiphichinhs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var chiphichinh = await _chiphichinhService.GetById(id);
            if (chiphichinh == null)
            {
                return NotFound();
            }
            return Ok(chiphichinh);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Chiphichinh chiphichinh)
        {
            await _chiphichinhService.Create(chiphichinh);
            return CreatedAtAction(nameof(GetById), new { id = chiphichinh.Machiphichinh }, chiphichinh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Chiphichinh chiphichinh)
        {
            if (!int.TryParse(id, out int chiphichinhId))
            {
                return BadRequest();
            }

         

            try
            {
                await _chiphichinhService.Update(id, chiphichinh);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var chiphichinh = await _chiphichinhService.GetById(id);
            if (chiphichinh == null)
            {
                return NotFound();
            }
            await _chiphichinhService.Delete(id);
            return NoContent();
        }
        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(Chiphichinhmodel chiphichinhmodel)
        {
            await _chiphichinhService.CreatebyModels(chiphichinhmodel);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            return Ok();
        }
        [HttpPost("create-chiphichinh")]
        public async Task<IActionResult> creatchiphichinh(string ChildResumeId, string thang_namhoc)
        {
            await _chiphichinhService.CreateChiphichinhByChildResumeId(ChildResumeId, thang_namhoc);
            return Ok();
        }
        [HttpPost("create-chiphichinhall")]
        public async Task<IActionResult> creatchiphichinhall( string thang_namhoc)
        {
            await _chiphichinhService.CreateChiphichinhByThangNamhoc( thang_namhoc);
            return Ok();
        }
        [HttpGet("hocvien-chiphichinh/{childResumeId}")]
        public async Task<IActionResult> GetByChildresumeId(string childResumeId)
        {
            var chiphichinh = await _chiphichinhService.GetByChildResumeId(childResumeId);
            if (chiphichinh == null)
            {
                return NotFound();
            }
            return Ok(chiphichinh);
        }
        [HttpDelete("delete-by-childresumeid/{childResumeId}")]
        public async Task<IActionResult> DeleteByChildResumeId(string childResumeId)
        {
            try
            {
                await _chiphichinhService.DeleteByChildResumeId(childResumeId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
