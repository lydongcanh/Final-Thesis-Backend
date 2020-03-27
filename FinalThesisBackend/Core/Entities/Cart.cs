using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class Cart : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<CartProductDetails> CartProductDetails { get; set; }
    }
}
