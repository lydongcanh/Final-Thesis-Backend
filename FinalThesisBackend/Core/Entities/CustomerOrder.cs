using System;
using System.Collections.Generic;
using FinalThesisBackend.Core.ValueObjects;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerOrder : BaseEntity
    {
        public string OrderState { get; set; }
        public Address ShipAddress { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<CustomerOrderDetails> OrderDetails { get; set; }
        public List<CustomerOrderStateDetails> StateDetails { get; set; }
    }
}
