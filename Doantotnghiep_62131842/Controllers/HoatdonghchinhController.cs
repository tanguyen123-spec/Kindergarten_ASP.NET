using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoatdonghchinhController : ControllerBase
    {
        private readonly IHoatdongchinhService _hoatdongchinhService;

        public HoatdonghchinhController(IHoatdongchinhService hoatdongchinhService)
        {
            _hoatdongchinhService = hoatdongchinhService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hoatdongchinh>>> GetAllHoatdongchinhs()
        {
            var hoatdongchinhs = await _hoatdongchinhService.GetAll();
            return Ok(hoatdongchinhs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hoatdongchinh>> GetHoatdongchinhById(string id)
        {
            var hoatdongchinh = await _hoatdongchinhService.GetById(id);
            if (hoatdongchinh == null)
            {
                return NotFound();
            }
            return Ok(hoatdongchinh);
        }

        [HttpPost]
        public async Task<ActionResult<Hoatdongchinh>> CreateHoatdongchinh(Hoatdongchinh hoatdongchinh)
        {
            await _hoatdongchinhService.Create(hoatdongchinh);
            return CreatedAtAction(nameof(GetHoatdongchinhById), new { id = hoatdongchinh.MaHoatdongchinh }, hoatdongchinh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoatdongchinh(string id, Hoatdongchinh hoatdongchinh)
        {
            if (id != hoatdongchinh.MaHoatdongchinh)
            {
                return BadRequest();
            }

            await _hoatdongchinhService.Update(id, hoatdongchinh);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoatdongchinh(string id)
        {
            await _hoatdongchinhService.Delete(id);
            return NoContent();
        }
    }
}
