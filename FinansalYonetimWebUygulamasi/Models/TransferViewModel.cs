using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace FinansalYonetimWebUygulamasi.Models
{
    public class TransferViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gönderen hesap gereklidir.")]
        public int SenderAccountId { get; set; }

        [Required(ErrorMessage = "Alıcı hesap gereklidir.")]
        public int RecipientAccountId { get; set; }

        [Required(ErrorMessage = "Miktar gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Lütfen geçerli bir miktar girin.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Tarih gereklidir.")]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public List<Account> SenderAccounts { get; set; } = new List<Account>();
        public List<Account> RecipientAccounts { get; set; } = new List<Account>();

    }
}
