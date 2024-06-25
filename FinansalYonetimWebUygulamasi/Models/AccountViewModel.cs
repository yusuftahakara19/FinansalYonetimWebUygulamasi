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
        public decimal Balance { get; set; }

        public int UserId { get; set; }
    }
}
