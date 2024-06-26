using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Mevcut Şifre alanı zorunludur.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Yeni Şifre alanı zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Yeni Şifre en az 6 karakter uzunluğunda olmalıdır.")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[-+_!@#$%^&*.,?]).+$", ErrorMessage = "Yeni Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni Şifre Tekrar alanı zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Yeni Şifre ve Yeni Şifre Tekrar eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
