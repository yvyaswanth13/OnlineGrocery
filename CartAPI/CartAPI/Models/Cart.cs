using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pname { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Total { get; set; }

        public virtual User EmailNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
