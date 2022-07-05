using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Myemail { get; set; }
        public string Pname { get; set; }
        public int? ProductId { get; set; }
        public string Address { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long? MobileNumber { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }

        public virtual User EmailNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
