using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; }
    }
}
