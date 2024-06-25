using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ExchangeRate
    {
        public string Currency { get; set; }
        public decimal Alis { get; set; }
        public decimal Satis { get; set; }
        public decimal Degisim { get; set; }
    }
}
