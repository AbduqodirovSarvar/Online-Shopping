using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Moduls
{
    public class ViewPayment
    {
        public int Contractid { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Summa { get; set; }
        public DateTime ToDate { get; set; }
    }
}
