using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class ProductCategoryConfiguration : IConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100);
            builder.HasOne(c => c.ParentCategory).WithMany(c => c.ChildrenCategories).HasForeignKey(c => c.ParentCategoryId);
        }
    }
}
