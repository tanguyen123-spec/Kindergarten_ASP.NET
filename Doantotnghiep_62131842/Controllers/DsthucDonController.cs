using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DsthucDonController : ControllerBase
    {
        private readonly IDsthucDonService _dsthucDonService;

        public DsthucDonController(IDsthucDonService dsthucDonService)
        {
            _dsthucDonService = dsthucDonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DsthucDon>>> GetAll()
        {
            var dsthucDonList = await _dsthucDonService.GetAll();
            return Ok(dsthucDonList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DsthucDon>> GetById(string id)
        {
            var dsthucDon = await _dsthucDonService.GetById(id);
            if (dsthucDon == null)
            {
                return NotFound();
            }

            return Ok(dsthucDon);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DsthucDon dsthucDon)
        {
            await _dsthucDonService.Create(dsthucDon);
            return CreatedAtAction(nameof(GetById), new { id = dsthucDon.MenuId }, dsthucDon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] DsthucDonModel dsthucDon)
        {
            await _dsthucDonService.Update(id, dsthucDon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _dsthucDonService.Delete(id);
            return NoContent();
        }

        [HttpPost("createbymodels")]
        public async Task<ActionResult> CreateByModels([FromBody] DsthucDonModel dsthucDon)
        {
            await _dsthucDonService.CreatebyModels(dsthucDon);
            return CreatedAtAction(nameof(GetById), new { id = dsthucDon.MenuId }, dsthucDon);
        }
       
    }
}
