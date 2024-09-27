using E_CommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; } // 1 Orderin 1 dən çox produktu olduğunu təmsil edir

        public Customer Customer { get; set; } // Sifarişin 1 müştərisi ola bilər
    }
}
