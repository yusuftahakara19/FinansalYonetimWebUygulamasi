using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hesap Adı alanı zorunludur.")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Bakiye alanı zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Lütfen geçerli bir değer giriniz.")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Lütfen geçerli bir bakiye değeri girin.")]
        public decimal Balance { get; set; }

        public int UserId { get; set; }
    }
}
