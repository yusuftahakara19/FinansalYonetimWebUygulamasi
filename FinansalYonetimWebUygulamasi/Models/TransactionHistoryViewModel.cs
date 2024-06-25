namespace FinansalYonetimWebUygulamasi.Models
{
    public class TransactionHistoryViewModel
    {
        public List<TransactionViewModel> Transactions { get; set; }
        public List<string> Categories { get; set; } = new List<string>
        {
           "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
        };
        public string SelectedCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
