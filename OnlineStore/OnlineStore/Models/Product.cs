using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStore.Models
{
    public partial class Product
    {
       // internal object Orders;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public string Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
