using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieudiemdanhController : ControllerBase
    {
        private readonly IPhieudiemdanhService _phieudiemdanhService;

        public PhieudiemdanhController(IPhieudiemdanhService phieudiemdanhService)
        {
            _phieudiemdanhService = phieudiemdanhService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phieudiemdanhList = await _phieudiemdanhService.GetAll();
            return Ok(phieudiemdanhList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var phieudiemdanh = await _phieudiemdanhService.GetById(id);
            if (phieudiemdanh == null)
            {
                return NotFound();
            }

            return Ok(phieudiemdanh);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Phieudiemdanh entity)
        {
            await _phieudiemdanhService.Create(entity);
            return Ok();
        }

        [HttpPost("createbymodels")]
        public async Task<IActionResult> CreateByModels([FromBody] PhieudiemdanhModel phieudiemdanh)
        {
            await _phieudiemdanhService.CreatebyModels(phieudiemdanh);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Phieudiemdanh entity)
        {
            await _phieudiemdanhService.Update(id, entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _phieudiemdanhService.Delete(id);
            return Ok();
        }
        [HttpGet("totaldiemdanh/{childResumeId}")]
        public async Task<IActionResult> GetByChildresumeID(string childResumeId)
        {
            var phieudiemdanh = await _phieudiemdanhService.GetTotalDiemDanhByChildResumeId(childResumeId);
            if (phieudiemdanh == null)
            {
                return NotFound();
            }

            return Ok(phieudiemdanh);
        }
        [HttpDelete("deletebychildresumeid/{childResumeId}")]
        public async Task<IActionResult> DeleteByChildResumeId(string childResumeId)
        {
            await _phieudiemdanhService.DeleteByChildResumeId(childResumeId);
            return NoContent();
        }

    }
}
