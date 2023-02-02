using Shop.Domain.Abstracts;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int ShopId { get; set; }
        public Shopping Shop { get; set; }
    }
}
