using System.ComponentModel.DataAnnotations;

namespace Doantotnghiep_62131842.Secure.Models
{
    public class LoginModels
    {
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}
