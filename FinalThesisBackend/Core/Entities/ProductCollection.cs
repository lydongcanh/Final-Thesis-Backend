using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class ProductCollection : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool ShowOnMainPage { get; set; }

        public List<ProductCollectionDetails> Details { get; set; }
    }
}
