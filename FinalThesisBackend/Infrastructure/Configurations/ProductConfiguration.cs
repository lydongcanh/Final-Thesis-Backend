using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class ProductConfiguration : IConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.MainImage).IsRequired();
            builder.Property(p => p.SubImages).HasConversion(
                i => JsonConvert.SerializeObject(i),
                i => JsonConvert.DeserializeObject<string[]>(i));
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasMany(p => p.ProductDetails).WithOne(pd => pd.Product).HasForeignKey(pd => pd.ProductId);
            builder.HasMany(p => p.ProductCollectionDetails).WithOne(pcd => pcd.Product).HasForeignKey(pcd => pcd.ProductId);
            builder.HasMany(p => p.CustomerProductDetails).WithOne(cpd => cpd.Product).HasForeignKey(cpd => cpd.ProductId);
        }
    }
}
