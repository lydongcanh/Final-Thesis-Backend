using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public List<Category> ChildrenCategories { get; set; }
        public List<Product> Products { get; set; }

        public bool IsRoot
        {
            get
            {
                return ParentCategory == null;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return ChildrenCategories == null;
            }
        }
    }
}
