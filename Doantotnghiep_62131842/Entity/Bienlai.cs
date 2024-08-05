using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doantotnghiep_62131842.Entity
{
    public class Bienlai
    {
        [Key]
        public string Mabienlai { get; set; }
        [ForeignKey("Hocvien")]
        public string ChildResumeId { get; set; }
        public int tongchiphiphaitra { get; set; }
        public bool trangthai { get; set; }
        public string thang_namhoc { get; set; }

        // Các thuộc tính khóa ngoại
        public Hocvien Hocvien { get; set; }
    }
}
