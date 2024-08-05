using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Services
{
 
    public interface IImagesTinhtrangsuckhoeService
    {
        Task<IEnumerable<ImagesTinhtrangsuckhoe>> GetAll();
        Task<ImagesTinhtrangsuckhoe> GetById(string id);
        Task Create(ImagesTinhtrangsuckhoe entity);
        Task CreatebyModels(ImagesTinhtrangsuckhoeModel imagesTinhtrangsuckhoe);
        Task Update(string id, ImagesTinhtrangsuckhoe entity);
        Task Delete(string id);
        Task UpdateImageUrl(string imagesTinhtrangsuckhoeId, string imageUrl);

    }
    public class ImagesTinhtrangsuckhoeService : IImagesTinhtrangsuckhoeService
    {
        private readonly IRepository<ImagesTinhtrangsuckhoe> _repository;
        private readonly MamnonProjectContext _context;
        public ImagesTinhtrangsuckhoeService(IRepository<ImagesTinhtrangsuckhoe> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(ImagesTinhtrangsuckhoe entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ImagesTinhtrangsuckhoe>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ImagesTinhtrangsuckhoe> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, ImagesTinhtrangsuckhoe entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(ImagesTinhtrangsuckhoeModel imagesTinhtrangsuckhoe)
        {
            var Im = new ImagesTinhtrangsuckhoe
            {
                

                ImagesTinhtrangsuckhoeId = imagesTinhtrangsuckhoe.ImagesTinhtrangsuckhoeId,
                TtskId = imagesTinhtrangsuckhoe.TtskId,
              

            };
            _context.ImagesTinhtrangsuckhoes.Add(Im);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateImageUrl(string imagesTinhtrangsuckhoeId, string imageUrl)
        {
            var images = await _context.ImagesTinhtrangsuckhoes.FirstOrDefaultAsync(p => p.ImagesTinhtrangsuckhoeId == imagesTinhtrangsuckhoeId);
            if (images != null)
            {
                images.LinkImage = imageUrl;

                await _context.SaveChangesAsync();
            }
        }


    }
}
