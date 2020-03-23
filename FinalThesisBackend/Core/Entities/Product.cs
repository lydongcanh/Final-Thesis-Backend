namespace FinalThesisBackend.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool IsSelling { get; set; }
        public string MainImage { get; set; }
        public string[] SubImages { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
