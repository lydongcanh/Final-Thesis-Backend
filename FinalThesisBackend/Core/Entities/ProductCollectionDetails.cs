using System;

namespace FinalThesisBackend.Core.Entities
{
    public class ProductCollectionDetails : BaseEntity
    {
        public override string Id { get =>  ProductId + ProductCollectionId; }

        public bool ShowOnMainPage { get; set; }
        public int Order { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string ProductCollectionId { get; set; }
        public ProductCollection ProductCollection { get; set; }
    }
}
