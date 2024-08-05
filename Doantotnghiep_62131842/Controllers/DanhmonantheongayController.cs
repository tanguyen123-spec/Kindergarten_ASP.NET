using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmonantheongayController : ControllerBase
    {
        private readonly IDanhmonantheongayService _danhmonantheongayService;

        public DanhmonantheongayController(IDanhmonantheongayService danhmonantheongayService)
        {
            _danhmonantheongayService = danhmonantheongayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Danhmonantheongay>>> GetAll()
        {
            var danhmonantheongays = await _danhmonantheongayService.GetAll();
            return Ok(danhmonantheongays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Danhmonantheongay>> GetById(string id)
        {
            var danhmonantheongay = await _danhmonantheongayService.GetById(id);
            if (danhmonantheongay == null)
            {
                return NotFound();
            }
            return Ok(danhmonantheongay);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Danhmonantheongay danhmonantheongay)
        {
            await _danhmonantheongayService.Create(danhmonantheongay);
            return CreatedAtAction(nameof(GetById), new { id = danhmonantheongay.Malichngay}, danhmonantheongay);
        }

        [HttpPost("models")]
        public async Task<ActionResult> CreatebyModels(DanhmonantheongayModel danhmonantheongayModel)
        {
            await _danhmonantheongayService.CreatebyModels(danhmonantheongayModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, Danhmonantheongay danhmonantheongay)
        {
            var existingDanhmonantheongay = await _danhmonantheongayService.GetById(id);
            if (existingDanhmonantheongay == null)
            {
                return NotFound();
            }
            await _danhmonantheongayService.Update(id, danhmonantheongay);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingDanhmonantheongay = await _danhmonantheongayService.GetById(id);
            if (existingDanhmonantheongay == null)
            {
                return NotFound();
            }
            await _danhmonantheongayService.Delete(id);
            return NoContent();
        }
        [HttpGet("menuId")]
        public async Task<ActionResult<string>> GetMenuIdByCurrentDate()
        {
            var menuId = await _danhmonantheongayService.GetMenuIdByCurrentDate();

            if (menuId == null)
            {
                return NotFound("Không tìm thấy menuId cho ngày hiện tại.");
            }

            return Ok(menuId);
        }
        [HttpGet("menuIdtd")]
        public async Task<ActionResult<string>> GetMenuIdByCurrentDatetd()
        {
            var menuId = await _danhmonantheongayService.GetMenuIdByCurrentDateTd();

            if (menuId == null)
            {
                return NotFound("Không tìm thấy menuId cho ngày hiện tại.");
            }

            return Ok(menuId);
        }
    }
}
