using System;

namespace FinalThesisBackend.Core.Entities
{
    public class CartProductDetails
    {
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public string ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
