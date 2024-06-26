using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad Soyad alanı gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "Şifre en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[-*!]).{6,}$", ErrorMessage = "Şifre en az bir büyük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string Password { get; set; }
    }
}
