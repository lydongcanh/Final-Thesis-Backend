using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class ProductDiscount : BaseEntity
    {
        public string Name { get; set; }
        public float DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
