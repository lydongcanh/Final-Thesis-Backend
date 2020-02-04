using System;
using System.Collections.Generic;

namespace FinalThesisBackend.Core.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> ChildrenCategories { get; set; }

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
