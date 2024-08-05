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
    [Route("api/[controller]")]
    [ApiController]
    public class SuckhoedinhkiController : ControllerBase
    {
        private readonly ISuckhoedinhkiService _suckhoedinhkiService;

        public SuckhoedinhkiController(ISuckhoedinhkiService suckhoedinhkiService)
        {
            _suckhoedinhkiService = suckhoedinhkiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suckhoedinhkis = await _suckhoedinhkiService.GetAll();
            return Ok(suckhoedinhkis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var suckhoedinhki = await _suckhoedinhkiService.GetById(id);
            if (suckhoedinhki == null)
                return NotFound();

            return Ok(suckhoedinhki);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Suckhoedinhki suckhoedinhki)
        {
            await _suckhoedinhkiService.Create(suckhoedinhki);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Suckhoedinhki suckhoedinhki)
        {
            await _suckhoedinhkiService.Update(id, suckhoedinhki);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _suckhoedinhkiService.Delete(id);
            return Ok();
        }
        [HttpPost("createbymodels")]
        public async Task<IActionResult> CreatebyModels(SuckhoedinhkiModel suckhoedinhki)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _suckhoedinhkiService.CreatebyModels(suckhoedinhki);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về phản hồi lỗi nếu cần thiết
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadCsv()
        {
            var data = await _suckhoedinhkiService.GetAllDisplay();

            var filteredData = data.Where(d => string.IsNullOrEmpty(d.Chieucao)
                                            || string.IsNullOrEmpty(d.Cannang)
                                            || string.IsNullOrEmpty(d.Benhlykhac)
                                            || string.IsNullOrEmpty(d.Ghichubacsy))
                                   .ToList();
            var recordsWithDate = filteredData.Select(record =>
            {
                record.Ngaykiemtra = DateTime.Now;
                return record;
            }).ToList();
            if (filteredData.Count == 0)
                return NoContent(); // Không có dữ liệu trống, trả về 204 No Content

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(recordsWithDate);
                }

                memoryStream.Seek(0, SeekOrigin.Begin); // Đặt lại vị trí của stream
                var content = memoryStream.ToArray();
                var fileName = $"data_{DateTime.Now:yyyyMMddHHmmss}.csv"; // Tạo tên file mới

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
                    var records = csv.GetRecords<SuckhoedinhkiUpdateDTO>().ToList();

                    using (var dbContext = new MamnonProjectContext()) // Thay YourDbContext bằng DbContext của bạn
                    {
                        foreach (var record in records)
                        {
                            var skdk = await dbContext.Suckhoedinhkis.FirstOrDefaultAsync(s => s.SkdkId == record.SkdkId);
                            if (skdk != null)
                            {
                                skdk.Chieucao = record.Chieucao;
                                skdk.Cannang = record.Cannang;
                                skdk.Benhlykhac = record.Benhlykhac;
                                skdk.Ghichubacsy = record.Ghichubacsy;

                                // Thêm trường Ngaykiemtra
                                skdk.Ngaykiemtra = DateTime.Now;

                                await dbContext.SaveChangesAsync();
                            }
                        }

                        await dbContext.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
                    }
                }
            }

            return Ok("File uploaded and processed.");
        }
        [HttpPost("create-for-class")]
        public async Task<IActionResult> CreateForClass(string malop)
        {
            await _suckhoedinhkiService.CreateForClass(malop);
            return Ok();
        }

    }
}
