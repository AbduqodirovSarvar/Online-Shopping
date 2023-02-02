using Shop.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Contract : Auditable
    {
        public Contract() 
        {
            Payments = new HashSet<Payment>();
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Duration { get; set; }
        public decimal Summa { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
