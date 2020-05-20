using System;
using System.Collections.Generic;
using FinalThesisBackend.Core.ValueObjects;

namespace FinalThesisBackend.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public List<CustomerOrderStateDetails> OrderStateDetails { get; set; }
    }
}
