using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStore.Models
{
    public partial class User
    {
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
    }
}
