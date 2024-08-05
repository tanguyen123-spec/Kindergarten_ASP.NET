using CsvHelper.Configuration.Attributes;

namespace Doantotnghiep_62131842.Model
{
    public class suckhoedinhkiexel
    {
        [Name("Mã sức khỏe định kì")]
        public string SkdkId { get; set; } = null!;
        [Name("Mã giáo viên")]
        public string? Magiaovien { get; set; }
        [Name("Tên giáo viên")]
        public string? Tengiaovien { get; set; }
        [Name("Mã học viên")]
        public string? ChildResumeId { get; set; }
        [Name("Tên học viên")]
        public string? Name { get; set; }
        [Name("Tên lớp")]
        public string? NameClass { get; set; }
        [Name("Loại lớp")]
        public string? NameClasstype { get; set; }

        [Name("Ngày kiểm tra")]
        public DateTime? Ngaykiemtra { get; set; }
        [Name("Chiều cao")]
        public string? Chieucao { get; set; }
        [Name("Cân nặng")]
        public string? Cannang { get; set; }
        [Name("Bệnh lý khác")]
        public string? Benhlykhac { get; set; }
        [Name("Ghi chú bác sỹ")]
        public string? Ghichubacsy { get; set; }
        [Name("Ngày tạo")]
        public DateTime? NgayTao { get; set; }
    }
}
