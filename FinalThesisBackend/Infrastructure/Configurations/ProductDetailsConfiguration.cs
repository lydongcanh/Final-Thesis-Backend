using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class ProductDetailsConfiguration : IConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.ToTable("ProductDetails");
            builder.Property(pd => pd.Size).HasMaxLength(20).IsRequired();
            builder.Property(pd => pd.Color).HasMaxLength(20).IsRequired();
            builder.Property(pd => pd.Description).HasMaxLength(100);
            builder.HasOne(pd => pd.Product).WithMany(p => p.Details).HasForeignKey(pd => pd.ProductId);
            builder.HasMany(pd => pd.CartProductDetails).WithOne(cpd => cpd.ProductDetails).HasForeignKey(cpd => cpd.ProductDetailsId);
        }
    }
}
