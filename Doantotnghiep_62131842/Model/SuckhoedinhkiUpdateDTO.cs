using CsvHelper.Configuration.Attributes;

namespace Doantotnghiep_62131842.Model
{
    public class SuckhoedinhkiUpdateDTO
    {
        [Name("Mã sức khỏe định kì")]
        public string SkdkId { get; set; }
        [Name("Chiều cao")]
        public string Chieucao { get; set; }
        [Name("Cân nặng")]
        public string Cannang { get; set; }
        [Name("Bệnh lý khác")]
        public string Benhlykhac { get; set; }
         [Name("Ghi chú bác sỹ")]
        public string Ghichubacsy { get; set; }
    }
}
