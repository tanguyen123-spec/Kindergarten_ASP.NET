using CsvHelper;
using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace Doantotnghiep_62131842.Controllers
{
    [ApiController]
    [Route("api/afnoondatasets")]
    public class AFnoondatasetController : ControllerBase
    {
        private readonly IAFnoondatasetService _service;

        public AFnoondatasetController(IAFnoondatasetService service)
        {
            _service = service;
        }

        // GET: api/afnoondatasets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AFnoondataset>>> GetAFnoondatasets()
        {
            var afnoondatasets = await _service.GetAll();
            return Ok(afnoondatasets);
        }

        // GET: api/afnoondatasets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AFnoondataset>> GetAFnoondataset(string id)
        {
            var afnoondataset = await _service.GetById(id);
            if (afnoondataset == null)
                return NotFound();

            return Ok(afnoondataset);
        }

        // POST: api/afnoondatasets
        [HttpPost]
        public async Task<ActionResult> CreateAFnoondataset(AFnoondataset afnoondataset)
        {
            await _service.Create(afnoondataset);
            return CreatedAtAction(nameof(GetAFnoondataset), new { id = afnoondataset.AFnoonid }, afnoondataset);
        }

        // PUT: api/afnoondatasets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAFnoondataset(string id, AFnoondataset afnoondataset)
        {
            await _service.Update(id, afnoondataset);
            return NoContent();
        }

        // DELETE: api/afnoondatasets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAFnoondataset(string id)
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
                        csv.WriteRecords(data.Select(d => new AFnoondataset
                        {
                            AFnoonid = d.AFnoonid,
                            FoodAF = d.FoodAF,
                            tpdduongAF = d.tpdduongAF
                            // Sao chép các trường dữ liệu khác mà bạn muốn xuất ra tệp CSV
                        }));
                    }
                    else
                    {
                        // Ghi một hàng tiêu đề trống để tạo tệp CSV trống
                        var emptyRecord = new AFnoondataset();
                        csv.WriteHeader<AFnoondataset>();
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

                    var records = csv.GetRecords<AFnoondataset>().ToList();

                    using (var dbContext = new MamnonProjectContext()) // Thay YourDbContext bằng DbContext của bạn
                    {
                        foreach (var record in records)
                        {
                            var afdataset = await dbContext.AFnoondatasets.FirstOrDefaultAsync(b => b.AFnoonid == record.AFnoonid);
                            if (afdataset != null)
                            {
                                afdataset.FoodAF = record.FoodAF;
                                afdataset.tpdduongAF = record.tpdduongAF;

                                // Cập nhật các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                dbContext.Update(afdataset);
                            }
                            else
                            {
                                // Tạo một BFastid ngẫu nhiên
                                var random = new Random();
                                var generatedBFastid = $"AF{random.Next(100000, 999999)}";
                                // Tạo một BFdataset mới với BFastid và các trường dữ liệu khác từ tệp CSV
                                afdataset = new AFnoondataset
                                {
                                    AFnoonid = generatedBFastid,
                                    FoodAF = record.FoodAF,
                                    tpdduongAF = record.tpdduongAF

                                    // Thiết lập các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                };

                                dbContext.Add(afdataset);
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
