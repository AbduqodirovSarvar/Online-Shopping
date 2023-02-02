using Shop.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Payment : Auditable
    {
        public int Contractid { get; set; }
        public Contract Contract { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Summa { get; set; }
        public DateTime ToDate { get; set; }
    }
}
