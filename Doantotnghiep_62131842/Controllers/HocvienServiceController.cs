using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocvienServiceController : ControllerBase
    {
        private readonly IHocVienService _hocVienService;
        private readonly IWebHostEnvironment _env;

        public HocvienServiceController(IHocVienService hocVienService, IWebHostEnvironment env)
        {
            _hocVienService = hocVienService ?? throw new ArgumentNullException(nameof(hocVienService));
            _env = env;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<Hocvien>>> GetAllHocVien()
        {
            var hocViens = await _hocVienService.GetAll();
            return Ok(hocViens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hocvien>> GetHocVienById(string id)
        {
            var hocVien = await _hocVienService.GetById(id);
            if (hocVien == null)
            {
                return NotFound();
            }
            return Ok(hocVien);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHocVien(Hocvien hocVien)
        {
            await _hocVienService.Create(hocVien);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHocVien(string id, Hocvien hocVien)
        {
            await _hocVienService.Update(id, hocVien);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHocVien(string id)
        {
            await _hocVienService.Delete(id);
            return Ok();
        }

        [HttpPost("CreateByModels")]
        public async Task<ActionResult> CreateHocVienByModels(HocvienModel hocvien)
        {
            await _hocVienService.CreatebyModels(hocvien);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            if (!string.IsNullOrEmpty(hocvien.ChildResumeId))
            {
                string imageUrl = GetImageByHocvien(hocvien.ChildResumeId);
                await _hocVienService.UpdateImageUrl(hocvien.ChildResumeId, imageUrl);
            }
            return Ok();
        }
        [HttpPost("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            try
            {
                var _uploadfiles = Request.Form.Files;
                foreach (IFormFile source in _uploadfiles)
                {
                    string Filename = source.FileName;
                    string Filepath = GetFilePath(Filename);

                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }
                    string imagepath = Filepath + "\\image.png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await source.CopyToAsync(stream);
                    }

                    // Trả về đường dẫn ảnh đã tải lên thành công
                    string imageUrl = "http://localhost:5160/Uploads/Hocvien/" + Filename + "/image.png";
                    return Ok(imageUrl);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (exception) ở đây
            }

            return BadRequest("Failed to upload image.");
        }
        [NonAction]
        private string GetFilePath(string hocviencode)
        {
            return this._env.WebRootPath + "\\Uploads\\Hocvien\\" + hocviencode;
        }
        [NonAction]
        private string GetImageByHocvien(string hocviencode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:5160/";
            string filepath = GetFilePath(hocviencode);
            string imagepath = filepath + "\\image.png";
            if (!System.IO.File.Exists(imagepath))
            {
                ImageUrl = HostUrl + "/Uploads/common/noimage.jpg";

            }
            else
            {
                ImageUrl = HostUrl + "/Uploads/Hocvien/" + hocviencode + "/image.png";
            }
            return ImageUrl;
        }
        [HttpGet("class/{classId}")]
        public async Task<ActionResult<IEnumerable<Hocvien>>> GetHocVienByClassId(string classId)
        {
            var hocViens = await _hocVienService.FindHocVienByClassId(classId);
            return Ok(hocViens);
        }
        [HttpPost("hocvien/update-classid")]
        public async Task<IActionResult> UpdateHocvienClassId(string oldClassId, string newClassId)
        {
            await _hocVienService.UpdateClassId(oldClassId, newClassId);
            return Ok();
        }

        [HttpGet("total-chiphi")]
        public async Task<ActionResult<decimal>> GetTotalChiPhi()
        {
            try
            {
                decimal totalChiPhi = await _hocVienService.CalculateTotalChiPhi();
                return Ok(totalChiPhi);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
