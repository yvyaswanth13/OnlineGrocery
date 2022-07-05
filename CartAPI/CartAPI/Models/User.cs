using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public long? MobileNumber { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
