using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CategoryConfiguration : IConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100);
            builder.HasOne(c => c.ParentCategory).WithMany(c => c.ChildrenCategories).HasForeignKey(c => c.ParentCategoryId);
        }
    }
}
