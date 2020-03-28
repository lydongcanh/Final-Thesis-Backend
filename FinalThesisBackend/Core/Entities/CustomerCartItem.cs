using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerCartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public string ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
