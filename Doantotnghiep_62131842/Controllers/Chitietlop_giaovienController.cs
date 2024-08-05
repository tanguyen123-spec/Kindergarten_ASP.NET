using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chitietlop_giaovienController : ControllerBase
    {
        private readonly Ichitietgiaovien_lopservice _chitietgiaovienLopService;

        public Chitietlop_giaovienController(Ichitietgiaovien_lopservice chitietgiaovienLopService)
        {
            _chitietgiaovienLopService = chitietgiaovienLopService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChitietgiaovienLop>>> GetAll()
        {
            try
            {
                var chitietgiaovienLops = await _chitietgiaovienLopService.GetAll();
                return Ok(chitietgiaovienLops);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChitietgiaovienLop>> GetById(string id)
        {
            try
            {
                var chitietgiaovienLop = await _chitietgiaovienLopService.GetById(id);
                if (chitietgiaovienLop == null)
                {
                    return NotFound();
                }
                return Ok(chitietgiaovienLop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(chitietlop_giaovienmodel model)
        {
            try
            {
                var chitietgiaovienLop = new ChitietgiaovienLop
                {
                    // Map properties from the model to the entity object
                    // Example: Property1 = model.Property1, Property2 = model.Property2
                };

                await _chitietgiaovienLopService.Create(chitietgiaovienLop);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, chitietlop_giaovienmodel model)
        {
            try
            {
                var chitietgiaovienLop = await _chitietgiaovienLopService.GetById(id);
                if (chitietgiaovienLop == null)
                {
                    return NotFound();
                }

                // Update properties of the entity object based on the model
                // Example: chitietgiaovienLop.Property1 = model.Property1, chitietgiaovienLop.Property2 = model.Property2

                await _chitietgiaovienLopService.Update(id, chitietgiaovienLop);
                return Ok();
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
                var chitietgiaovienLop = await _chitietgiaovienLopService.GetById(id);
                if (chitietgiaovienLop == null)
                {
                    return NotFound();
                }

                await _chitietgiaovienLopService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
