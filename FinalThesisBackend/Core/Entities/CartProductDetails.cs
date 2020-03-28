using System;

namespace FinalThesisBackend.Core.Entities
{
    /// <summary>
    /// Cart - ProductDetails join entity.
    /// </summary>
    public class CartProductDetails : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public string ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
