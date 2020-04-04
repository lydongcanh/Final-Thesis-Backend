using System;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerProductDetails : BaseEntity
    {
        public override string Id { get => CustomerId + ProductId; }

        public int Rate { get; set; }
        public bool Liked { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
