using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoatdongController : ControllerBase
    {
        private readonly IHoatDongsService _hoatDongsService;

        public HoatdongController(IHoatDongsService hoatDongsService)
        {
            _hoatDongsService = hoatDongsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hoatdong>>> GetAllHoatdongs()
        {
            var hoatdongs = await _hoatDongsService.GetAll();
            return Ok(hoatdongs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hoatdong>> GetHoatdongById(string id)
        {
            var hoatdong = await _hoatDongsService.GetById(id);
            if (hoatdong == null)
            {
                return NotFound();
            }
            return Ok(hoatdong);
        }

        [HttpPost]
        public async Task<ActionResult<Hoatdong>> CreateHoatdong(Hoatdong hoatdong)
        {
            await _hoatDongsService.Create(hoatdong);
            return CreatedAtAction(nameof(GetHoatdongById), new { id = hoatdong.Mahoatdong }, hoatdong);
        }

        [HttpPost("create-by-models")]
        public async Task<ActionResult<Hoatdong>> CreateHoatdongByModels(HoatdongModel hoatdongModel)
        {
            await _hoatDongsService.CreatebyModels(hoatdongModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoatdong(string id, Hoatdong hoatdong)
        {
            if (id != hoatdong.Mahoatdong)
            {
                return BadRequest();
            }

            await _hoatDongsService.Update(id, hoatdong);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoatdong(string id)
        {
            await _hoatDongsService.Delete(id);
            return NoContent();
        }
    }
}
