using Shop.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Shopping : Auditable
    {
        public Shopping() {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set;}
    }
}
