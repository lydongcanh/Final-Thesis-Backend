using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CartProductDetailsConfiguration : IConfiguration<CartProductDetails>
    {
        public void Configure(EntityTypeBuilder<CartProductDetails> builder)
        {
            builder.ToTable("Cart_ProductDetails");
            builder.HasKey(cpd => new { cpd.CartId, cpd.ProductDetailsId });
            builder.Property(cpd => cpd.Quantity).IsRequired();
            builder.Property(cpd => cpd.AddedDate).IsRequired();
        }
    }
}
