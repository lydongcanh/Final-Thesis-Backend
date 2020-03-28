using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerCartItem : BaseEntity
    {
        public override string Id { get { return CustomerId + ProductDetailsId; } }

        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
