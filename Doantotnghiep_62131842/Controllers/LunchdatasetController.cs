using CsvHelper;
using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace Doantotnghiep_62131842.Controllers
{
    [ApiController]
    [Route("api/lunchdatasets")]
    public class LunchdatasetController : ControllerBase
    {
        private readonly ILunchdatasetService _service;

        public LunchdatasetController(ILunchdatasetService service)
        {
            _service = service;
        }

        // GET: api/lunchdatasets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lunchdataset>>> GetLunchdatasets()
        {
            var lunchdatasets = await _service.GetAll();
            return Ok(lunchdatasets);
        }

        // GET: api/lunchdatasets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Lunchdataset>> GetLunchdataset(string id)
        {
            var lunchdataset = await _service.GetById(id);
            if (lunchdataset == null)
                return NotFound();

            return Ok(lunchdataset);
        }

        // POST: api/lunchdatasets
        [HttpPost]
        public async Task<ActionResult> CreateLunchdataset(Lunchdataset lunchdataset)
        {
            await _service.Create(lunchdataset);
            return CreatedAtAction(nameof(GetLunchdataset), new { id = lunchdataset.LunchId }, lunchdataset);
        }

        // PUT: api/lunchdatasets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLunchdataset(string id, Lunchdataset lunchdataset)
        {
            await _service.Update(id, lunchdataset);
            return NoContent();
        }

        // DELETE: api/lunchdatasets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLunchdataset(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }
        [HttpGet("download")]
        public async Task<IActionResult> DownloadCsv()
        {
            var data = await _service.GetAll();

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (data.Count() > 0)
                    {
                        csv.WriteRecords(data.Select(d => new Lunchdataset
                        {
                             LunchId= d.LunchId,
                            FoodLunch = d.FoodLunch,
                            tpdduongL = d.tpdduongL
                            // Sao chép các trường dữ liệu khác mà bạn muốn xuất ra tệp CSV
                        }));
                    }
                    else
                    {
                        // Ghi một hàng tiêu đề trống để tạo tệp CSV trống
                        var emptyRecord = new Desertdataset();
                        csv.WriteHeader<Lunchdataset>();
                        csv.NextRecord();
                        csv.WriteRecord(emptyRecord);
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin); // Đặt lại vị trí của stream
                var content = memoryStream.ToArray();
                var fileName = $"data_BF{DateTime.Now:yyyyMMddHHmmss}.csv"; // Tạo tên file mới

                return new FileContentResult(content, "text/csv; charset=utf-8")
                {
                    FileDownloadName = fileName
                };
            }
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Đọc tệp CSV đã tải lên
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(memoryStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var records = csv.GetRecords<Lunchdataset>().ToList();

                    using (var dbContext = new MamnonProjectContext()) // Thay YourDbContext bằng DbContext của bạn
                    {
                        foreach (var record in records)
                        {
                            var lunchdataset = await dbContext.Lunchdatasets.FirstOrDefaultAsync(b => b.LunchId == record.LunchId);
                            if (lunchdataset != null)
                            {
                                lunchdataset.FoodLunch = record.FoodLunch;
                                lunchdataset.tpdduongL = record.tpdduongL;

                                // Cập nhật các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                dbContext.Update(lunchdataset);
                            }
                            else
                            {
                                // Tạo một BFastid ngẫu nhiên
                                var random = new Random();
                                var generatedBFastid = $"LH{random.Next(100000, 999999)}";
                                // Tạo một BFdataset mới với BFastid và các trường dữ liệu khác từ tệp CSV
                                lunchdataset = new Lunchdataset
                                {
                                    LunchId = generatedBFastid,
                                    FoodLunch = record.FoodLunch,
                                    tpdduongL = record.tpdduongL

                                    // Thiết lập các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                };

                                dbContext.Add(lunchdataset);
                            }
                        }

                        await dbContext.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
                    }
                }
            }

            return Ok("File uploaded and processed.");
        }
    }
}
