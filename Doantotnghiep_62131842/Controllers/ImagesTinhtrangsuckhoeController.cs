using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doantotnghiep_62131842.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesTinhtrangsuckhoeController : ControllerBase
    {
        private readonly IImagesTinhtrangsuckhoeService _imagesTinhtrangsuckhoeService;
        private readonly IWebHostEnvironment _env;

        public ImagesTinhtrangsuckhoeController(IImagesTinhtrangsuckhoeService imagesTinhtrangsuckhoeService, IWebHostEnvironment env)
        {
            _imagesTinhtrangsuckhoeService = imagesTinhtrangsuckhoeService;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagesTinhtrangsuckhoe>>> GetAllImagesTinhtrangsuckhoe()
        {
            var images = await _imagesTinhtrangsuckhoeService.GetAll();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagesTinhtrangsuckhoe>> GetImagesTinhtrangsuckhoeById(string id)
        {
            var image = await _imagesTinhtrangsuckhoeService.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagesTinhtrangsuckhoe(ImagesTinhtrangsuckhoeModel imagesTinhtrangsuckhoe)
        {
           
                await _imagesTinhtrangsuckhoeService.CreatebyModels(imagesTinhtrangsuckhoe);
            // Gọi phương thức GetImageByHocvien để lấy đường dẫn ảnh đúng
            if (!string.IsNullOrEmpty(imagesTinhtrangsuckhoe.ImagesTinhtrangsuckhoeId))
            {
                string imageUrl = GetImageBySuckhoehangngay(imagesTinhtrangsuckhoe.ImagesTinhtrangsuckhoeId);
                await _imagesTinhtrangsuckhoeService.UpdateImageUrl(imagesTinhtrangsuckhoe.ImagesTinhtrangsuckhoeId, imageUrl);
            }
            return Ok();



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImagesTinhtrangsuckhoe(string id, ImagesTinhtrangsuckhoe imagesTinhtrangsuckhoe)
        {
            try
            {
                await _imagesTinhtrangsuckhoeService.Update(id, imagesTinhtrangsuckhoe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagesTinhtrangsuckhoe(string id)
        {
            try
            {
                await _imagesTinhtrangsuckhoeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                    string imageUrl = "http://localhost:5160/Uploads/Suckhoehangngay/" + Filename + "/image.png";
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
            return this._env.WebRootPath + "\\Uploads\\Suckhoehangngay\\" + hocviencode;
        }
        [NonAction]
        private string GetImageBySuckhoehangngay(string SKcode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:5160/";
            string filepath = GetFilePath(SKcode);
            string imagepath = filepath + "\\image.png";
            if (!System.IO.File.Exists(imagepath))
            {
                ImageUrl = HostUrl + "/Uploads/common/noimage.jpg";

            }
            else
            {
                ImageUrl = HostUrl + "/Uploads/Suckhoehangngay/" + SKcode + "/image.png";
            }
            return ImageUrl;
        }
    }
}
