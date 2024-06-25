using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class TransactionViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Miktar gereklidir.")]
        [Range(0, double.MaxValue, ErrorMessage = "Lütfen geçerli bir miktar girin.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Tarih gereklidir.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Kategori gereklidir.")]
        public string Category { get; set; }

        public int UserId { get; set; }

        public List<string> Categories { get; set; } = new List<string>
        {
            "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
        };

    }
}
