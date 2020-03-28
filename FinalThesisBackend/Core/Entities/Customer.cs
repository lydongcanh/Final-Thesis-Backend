using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string VipLevel { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public List<CustomerCartItem> CartItems { get; set; }
    }
}
