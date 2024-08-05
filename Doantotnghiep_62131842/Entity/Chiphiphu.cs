using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Doantotnghiep_62131842.Entity
{
    public class Chiphiphu
    {



        [Key]
        [MaxLength(10)]
        public string Machiphiphu { get; set; }

        [Required]
        [ForeignKey("Hoatdong")]
        [MaxLength(10)]
        public string Mahoatdong { get; set; }

        [Required]
        [ForeignKey("Hocvien")]
        [MaxLength(10)]
        public string Child_resume_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Thang_namhoc { get; set; }

        // Navigation properties
        public Hoatdong Hoatdong { get; set; }
        public Hocvien Hocvien { get; set; }
    }
}
