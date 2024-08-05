using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuhuynhController : ControllerBase
    {
        private readonly IPhuhuynhService _phuhuynhService;

        public PhuhuynhController(IPhuhuynhService phuhuynhService)
        {
            _phuhuynhService = phuhuynhService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phuhuynh>>> GetAll()
        {
            var phuhuynhs = await _phuhuynhService.GetAll();
            return Ok(phuhuynhs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Phuhuynh>> GetById(string id)
        {
            var phuhuynh = await _phuhuynhService.GetById(id);
            if (phuhuynh == null)
                return NotFound();

            return Ok(phuhuynh);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PhuhuynhModel phuhuynh)
        {
            try
            {
                await _phuhuynhService.CreatebyModels(phuhuynh);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while creating the Phuhuynh.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Phuhuynh phuhuynh)
        {
            try
            {
                await _phuhuynhService.Update(id, phuhuynh);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while updating the Phuhuynh.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _phuhuynhService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error response
                return StatusCode(500, "An error occurred while deleting the Phuhuynh.");
            }
        }
        [HttpPost("create-by-models")]
        public async Task<ActionResult> CreateByModels([FromBody] PhuhuynhModel ph)
        {
            
                await _phuhuynhService.CreatebyModels(ph);
                return Ok();
          
           
        }
    }
}
