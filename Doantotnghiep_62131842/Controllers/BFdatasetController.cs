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
    [Route("api/bfdatasets")]
    public class BFdatasetController : ControllerBase
    {
        private readonly IBFdatasetService _service;

        public BFdatasetController(IBFdatasetService service)
        {
            _service = service;
        }

        // GET: api/bfdatasets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BFdataset>>> GetBFdatasets()
        {
            var bfdatasets = await _service.GetAll();
            return Ok(bfdatasets);
        }

        // GET: api/bfdatasets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BFdataset>> GetBFdataset(string id)
        {
            var bfdataset = await _service.GetById(id);
            if (bfdataset == null)
                return NotFound();

            return Ok(bfdataset);
        }

        // POST: api/bfdatasets
        [HttpPost]
        public async Task<ActionResult> CreateBFdataset(BFdataset bfdataset)
        {
            await _service.Create(bfdataset);
            return CreatedAtAction(nameof(GetBFdataset), new { id = bfdataset.BFastid }, bfdataset);
        }

        // PUT: api/bfdatasets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBFdataset(string id, BFdataset bfdataset)
        {
            await _service.Update(id, bfdataset);
            return NoContent();
        }

        // DELETE: api/bfdatasets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBFdataset(string id)
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
                        csv.WriteRecords(data.Select(d => new BFdatasetExport
                        {
                            BFastid=d.BFastid,
                            FoodBF = d.FoodBF,
                            tpdduongBF = d.tpdduongBF
                            // Sao chép các trường dữ liệu khác mà bạn muốn xuất ra tệp CSV
                        }));
                    }
                    else
                    {
                        // Ghi một hàng tiêu đề trống để tạo tệp CSV trống
                        var emptyRecord = new BFdatasetExport();
                        csv.WriteHeader<BFdatasetExport>();
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
            

            // Đọc tệp CSV đã tải lên
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(memoryStream, Encoding.UTF8))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<BFdataset>().ToList();

                    using (var dbContext = new MamnonProjectContext()) // Thay YourDbContext bằng DbContext của bạn
                    {
                        foreach (var record in records)
                        {
                            var bfdataset = await dbContext.BFdatasets.FirstOrDefaultAsync(b => b.BFastid == record.BFastid);
                            if (bfdataset != null)
                            {
                                bfdataset.FoodBF = record.FoodBF;
                                bfdataset.tpdduongBF = record.tpdduongBF;

                                // Cập nhật các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                dbContext.Update(bfdataset);
                            }
                            else
                            {
                                // Tạo một BFastid ngẫu nhiên
                                var random = new Random();
                                var generatedBFastid = $"BF{random.Next(100000, 999999)}";
                                // Tạo một BFdataset mới với BFastid và các trường dữ liệu khác từ tệp CSV
                                bfdataset = new BFdataset
                                {
                                    BFastid = generatedBFastid,
                                    FoodBF = record.FoodBF,
                                    tpdduongBF = record.tpdduongBF

                                    // Thiết lập các trường dữ liệu khác của BFdataset theo yêu cầu của bạn
                                };

                                dbContext.Add(bfdataset);
                            }
                        }

                        await dbContext.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
                    }
                }
            }

            return Ok("File uploaded and processed.");
        }
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                await _service.DeleteAll();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the delete process
                return StatusCode(500, ex.Message);
            }
        }

    }
}
