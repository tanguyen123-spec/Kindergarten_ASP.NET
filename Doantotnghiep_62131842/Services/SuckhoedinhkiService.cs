using CsvHelper;
using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Model;
using Doantotnghiep_62131842.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Linq;
using OfficeOpenXml;

namespace Doantotnghiep_62131842.Services
{

    public interface ISuckhoedinhkiService
    {
        Task<IEnumerable<Suckhoedinhki>> GetAll();
        Task<Suckhoedinhki> GetById(string id);
        Task Create(Suckhoedinhki entity);
        Task CreatebyModels(SuckhoedinhkiModel suckhoedinhki);
        Task Update(string id, Suckhoedinhki entity);
        Task Delete(string id);
        Task<IEnumerable<suckhoedinhkiexel>> GetAllDisplay();
        Task<bool> UpdateFromCsv(Stream stream);
        Task CreateForClass(string malop);
    }
    public class SuckhoedinhkiService : ISuckhoedinhkiService
    {
        private readonly IRepository<Suckhoedinhki> _repository;
        private readonly MamnonProjectContext _context;
        public SuckhoedinhkiService(IRepository<Suckhoedinhki> repository, MamnonProjectContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Suckhoedinhki entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Suckhoedinhki>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Suckhoedinhki> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Suckhoedinhki entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(SuckhoedinhkiModel suckhoedinhki)
        {
            var skdk = new Suckhoedinhki
            {


                SkdkId = suckhoedinhki.SkdkId,
                Magiaovien = suckhoedinhki.Magiaovien,
                ChildResumeId = suckhoedinhki.ChildResumeId,
                Ngaykiemtra = suckhoedinhki.Ngaykiemtra,
                Chieucao = suckhoedinhki.Chieucao,
                Cannang = suckhoedinhki.Cannang,
                Benhlykhac = suckhoedinhki.Benhlykhac,
                Ghichubacsy = suckhoedinhki.Ghichubacsy,
                NgayTao = suckhoedinhki.NgayTao,


            };
            _context.Suckhoedinhkis.Add(skdk);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<suckhoedinhkiexel>> GetAllDisplay()
        {
            var skdkex = await (from skdk in _context.Suckhoedinhkis
                                join hv in _context.Hocviens on skdk.ChildResumeId equals hv.ChildResumeId
                                join gv in _context.Giaoviens on skdk.Magiaovien equals gv.Magiaovien
                                join lop in _context.Lops on hv.ClassId equals lop.ClassId
                                join loailop in _context.Loailops on lop.ClasstypeId equals loailop.ClasstypeId
                                select new suckhoedinhkiexel
                                {
                                    SkdkId = skdk.SkdkId,
                                    Magiaovien= skdk.Magiaovien,
                                    Tengiaovien= gv.Tengiaovien,
                                    ChildResumeId= skdk.ChildResumeId,
                                    NameClass = lop.NameClass,
                                    NameClasstype=loailop.NameClasstype,
                                    Name = hv.Name,
                                    Ngaykiemtra = skdk.Ngaykiemtra,
                                    Chieucao= skdk.Chieucao,
                                     Cannang = skdk.Cannang,
                                     Benhlykhac = skdk.Benhlykhac,
                                     Ghichubacsy= skdk.Ghichubacsy,
                                     NgayTao= skdk.NgayTao,
                                }).ToListAsync();

            return skdkex;
        }
        public async Task<bool> UpdateFromCsv(Stream stream)
        {
            try
            {
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<SuckhoedinhkiUpdateDTO>().ToList();

                    var updateData = new Dictionary<string, SuckhoedinhkiUpdateDTO>();

                    foreach (var record in records)
                    {
                        if (!updateData.ContainsKey(record.SkdkId))
                        {
                            updateData.Add(record.SkdkId, record);
                        }
                        else
                        {
                            var existingData = updateData[record.SkdkId];
                            existingData.Chieucao = record.Chieucao;
                            existingData.Cannang = record.Cannang;
                            existingData.Benhlykhac = record.Benhlykhac;
                            existingData.Ghichubacsy = record.Ghichubacsy;
                        }
                    }

                    foreach (var kvp in updateData)
                    {
                        await UpdateSuckhoedinhki(kvp.Key, kvp.Value);
                    }
                }

                return true; // Return true if data update was successful
            }
            catch (Exception ex)
            {
                // Handle any errors that occurred during the CSV processing
                // Log, display error messages, etc.
                return false; // Return false if an error occurred
            }
        }
        private async Task UpdateSuckhoedinhki(string skdkId, SuckhoedinhkiUpdateDTO updateData)
        {
            var skdk = await _context.Suckhoedinhkis.FirstOrDefaultAsync(s => s.SkdkId == skdkId);
            if (skdk != null)
            {
                skdk.Chieucao = updateData.Chieucao;
                skdk.Cannang = updateData.Cannang;
                skdk.Benhlykhac = updateData.Benhlykhac;
                skdk.Ghichubacsy = updateData.Ghichubacsy;

                await _context.SaveChangesAsync();
            }
        }
        public async Task CreateForClass(string malop)
        {
            var hocviens = await _context.Hocviens.Where(hv => hv.ClassId == malop).ToListAsync();

            foreach (var hocvien in hocviens)
            {
                var skdk = new Suckhoedinhki
                {
                    SkdkId = GenerateSkdkId(), // Tự động tạo mã skdkId
                    Magiaovien = "GV001", // Mã giáo viên mặc định
                    ChildResumeId = hocvien.ChildResumeId,
                    Ngaykiemtra =null, // Ngày kiểm tra là ngày hiện tại
                    Chieucao = null, // Để trống ban đầu
                    Cannang = null, // Để trống ban đầu
                    Benhlykhac = null, // Để trống ban đầu
                    Ghichubacsy = null, // Để trống ban đầu
                    NgayTao = DateTime.Now // Ngày tạo là ngày hiện tại
                };

                _context.Suckhoedinhkis.Add(skdk);
            }

            await _context.SaveChangesAsync();
        }
        private string GenerateSkdkId()
        {
            // Lấy danh sách mã skdkId hiện có trong cơ sở dữ liệu
            var existingSkdkIds = _context.Suckhoedinhkis.Select(skdk => skdk.SkdkId).ToList();

            string skdkId;
            var random = new Random();

            do
            {
                // Tạo mã skdkId ngẫu nhiên
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("SK");

                for (int i = 0; i < 8; i++)
                {
                    char randomChar = (char)random.Next('0', '9' + 1); // Chọn một ký tự số từ 0-9 ngẫu nhiên
                    stringBuilder.Append(randomChar);
                }
                skdkId = stringBuilder.ToString();
            }
            while (existingSkdkIds.Contains(skdkId)); // Kiểm tra xem mã skdkId đã tồn tại hay chưa

            return skdkId;
        }
    }
}
