using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
