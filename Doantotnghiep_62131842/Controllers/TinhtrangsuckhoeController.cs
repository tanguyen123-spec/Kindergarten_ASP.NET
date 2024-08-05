using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhtrangsuckhoeController : ControllerBase
    {
        private readonly ITinhtrangsuckhoeService _tinhtrangsuckhoeService;

        public TinhtrangsuckhoeController(ITinhtrangsuckhoeService tinhtrangsuckhoeService)
        {
            _tinhtrangsuckhoeService = tinhtrangsuckhoeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tinhtrangsuckhoe>>> GetAll()
        {
            try
            {
                var tinhtrangsuckhoes = await _tinhtrangsuckhoeService.GetAll();
                return Ok(tinhtrangsuckhoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tinhtrangsuckhoe>> GetById(string id)
        {
            try
            {
                var tinhtrangsuckhoe = await _tinhtrangsuckhoeService.GetById(id);
                if (tinhtrangsuckhoe == null)
                    return NotFound();

                return Ok(tinhtrangsuckhoe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tinhtrangsuckhoe tinhtrangsuckhoe)
        {
            try
            {
                await _tinhtrangsuckhoeService.Create(tinhtrangsuckhoe);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("models")]
        public async Task<IActionResult> CreateByModels([FromBody] TinhtrangsuckhoeModel tinhtrangsuckhoe)
        {
           
                await _tinhtrangsuckhoeService.CreatebyModels(tinhtrangsuckhoe);
                return Ok();
            
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Tinhtrangsuckhoe tinhtrangsuckhoe)
        {
            try
            {
                await _tinhtrangsuckhoeService.Update(id, tinhtrangsuckhoe);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _tinhtrangsuckhoeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
