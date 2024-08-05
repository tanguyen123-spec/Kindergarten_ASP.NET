using CsvHelper;
using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Text;

namespace Doantotnghiep_62131842.Controllers
{
    [ApiController]
    [Route("api/desertdatasets")]
    public class DesertdatasetController : ControllerBase
    {
        private readonly IDesertdatasetService _service;

        public DesertdatasetController(IDesertdatasetService service)
        {
            _service = service;
        }

        // GET: api/desertdatasets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desertdataset>>> GetDesertdatasets()
        {
            var desertdatasets = await _service.GetAll();
            return Ok(desertdatasets);
        }

        // GET: api/desertdatasets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Desertdataset>> GetDesertdataset(string id)
        {
            var desertdataset = await _service.GetById(id);
            if (desertdataset == null)
                return NotFound();

            return Ok(desertdataset);
        }

        // POST: api/desertdatasets
        [HttpPost]
        public async Task<ActionResult> CreateDesertdataset(Desertdataset desertdataset)
        {
            await _service.Create(desertdataset);
            return CreatedAtAction(nameof(GetDesertdataset), new { id = desertdataset.DSertid }, desertdataset);
        }

        // PUT: api/desertdatasets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDesertdataset(string id, Desertdataset desertdataset)
        {
            await _service.Update(id, desertdataset);
            return NoContent();
        }

        // DELETE: api/desertdatasets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDesertdataset(string id)
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
                        csv.WriteRecords(data.Select(d => new Desertdataset
                        {
                            DSertid = d.DSertid,
                            FoodDS = d.FoodDS,
                            tpdduongDS = d.tpdduongDS
                            // Sao chép các trường dữ liệu khác mà bạn muốn xuất ra tệp CSV
                        }));
                    }
                    else
                    {
                        // Ghi một hàng tiêu đề trống để tạo tệp CSV trống
                        var emptyRecord = new Desertdataset();
                        csv.WriteHeader<Desertdataset>();
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

                    var records = csv.GetRecords<Desertdataset>().ToList();

                    using (var dbContext = new MamnonProjectContext()) // Thay YourDbContext bằng DbContext của bạn
                    {
                        foreach (var record in records)
                        {
                            var dsdataset = await dbContext.Desertdatasets.FirstOrDefaultAsync(b => b.DSertid == record.DSertid);
                            if (dsdataset != null)
                            {
                                dsdataset.FoodDS = record.FoodDS;
                                dsdataset.tpdduongDS = record.tpdduongDS;

                                // Cập nhật các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                dbContext.Update(dsdataset);
                            }
                            else
                            {
                                // Tạo một BFastid ngẫu nhiên
                                var random = new Random();
                                var generatedBFastid = $"DS{random.Next(100000, 999999)}";
                                // Tạo một BFdataset mới với BFastid và các trường dữ liệu khác từ tệp CSV
                                dsdataset = new Desertdataset
                                {
                                    DSertid = generatedBFastid,
                                    FoodDS = record.FoodDS,
                                    tpdduongDS = record.tpdduongDS

                                      // Thiết lập các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                  };

                                dbContext.Add(dsdataset);
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
