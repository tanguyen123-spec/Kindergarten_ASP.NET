using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly ILopService _lopService;

        public LopController(ILopService lopService)
        {
            _lopService = lopService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lop>>> GetAll()
        {
            var lops = await _lopService.GetAll();
            return Ok(lops);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lop>> GetById(string id)
        {
            var lop = await _lopService.GetById(id);
            if (lop == null)
                return NotFound();

            return Ok(lop);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Lop lop)
        {
            try
            {
                await _lopService.Create(lop);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while creating the Lop.");
            }
        }

        [HttpPost("create-by-models")]
        public async Task<ActionResult> CreateByModels([FromBody] LopModel lop)
        {
            try
            {
                await _lopService.CreatebyModels(lop);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while creating the Lop by model.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Lop lop)
        {
            try
            {
                await _lopService.Update(id, lop);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while updating the Lop.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _lopService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while deleting the Lop.");
            }
        }
        [HttpGet("display/{namhoc}/{classtypeId}")]
        public async Task<ActionResult<IEnumerable<string>>> GetClassesByNamhocAndClasstypeId(string namhoc, string classtypeId)
        {
            var classIds = await _lopService.GetAllDisplay(namhoc, classtypeId);
            return Ok(classIds);
        }
    }
}
