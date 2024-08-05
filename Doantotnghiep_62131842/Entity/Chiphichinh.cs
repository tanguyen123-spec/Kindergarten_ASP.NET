using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Doantotnghiep_62131842.Entity
{
    public class Chiphichinh
    {
        [Key]
        public string Machiphichinh { get; set; }

        [ForeignKey("Hoatdong")]
        public string Mahoatdong { get; set; }

        [ForeignKey("Hocvien")]
        public string ChildResumeId { get; set; }

     
        public string  thang_namhoc { get; set; }

       

        public Hoatdong Hoatdong { get; set; }
        public Hocvien hocvien { get; set; }
    }
}
