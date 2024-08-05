using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BienlaiController : ControllerBase
    {
        private readonly IBienlaiService _bienlaiService;

        public BienlaiController(IBienlaiService bienlaiService)
        {
            _bienlaiService = bienlaiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bienlais = await _bienlaiService.GetAll();
            return Ok(bienlais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var bienlai = await _bienlaiService.GetById(id);
            if (bienlai == null)
                return NotFound();

            return Ok(bienlai);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BienlaiModel bienlai)
        {
            try
            {
                await _bienlaiService.CreateByModel(bienlai);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Bienlai bienlai)
        {
            try
            {
                await _bienlaiService.Update(id, bienlai);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _bienlaiService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(BienlaiModel bienlaiModel)
        {
            await _bienlaiService.CreateByModel(bienlaiModel);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            return Ok();
        }
        [HttpGet("thong-ke-theo-thang-nam-hoc")]
        public async Task<IActionResult> ThongKeTheoThangNamHoc()
        {
            var thongKeList = await _bienlaiService.ThongKeTheoThangNamHoc();
            return Ok(thongKeList);
        }
    }
}
