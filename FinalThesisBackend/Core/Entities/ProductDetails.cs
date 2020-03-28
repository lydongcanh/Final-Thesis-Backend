using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class ProductDetails : BaseEntity
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public List<CustomerCartItem> CartProductDetails { get; set; }
    }
}
