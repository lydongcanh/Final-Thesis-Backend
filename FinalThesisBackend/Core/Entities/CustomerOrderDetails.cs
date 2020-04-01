using System;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerOrderDetails : BaseEntity
    {
        public override string Id { get => ProductDetailsId + CustomerOrderId; }

        public int Quantity { get; set; }
        public float PurchasedPrice { get; set; }

        public string ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }

        public string CustomerOrderId { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
    }
}
