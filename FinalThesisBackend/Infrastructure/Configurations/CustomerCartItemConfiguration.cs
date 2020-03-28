using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerCartItemConfiguration : IConfiguration<CustomerCartItem>
    {
        public void Configure(EntityTypeBuilder<CustomerCartItem> builder)
        {
            builder.Ignore(cci => cci.Id);
            builder.HasKey(cci => new { cci.CustomerId, cci.ProductDetailsId });
            builder.Property(cci => cci.Quantity).IsRequired();
            builder.Property(cci => cci.AddedDate).IsRequired();
            builder.HasOne(cci => cci.Customer).WithMany(c => c.CartItems).HasForeignKey(cci => cci.CustomerId);
            builder.HasOne(cci => cci.ProductDetails).WithMany(pd => pd.CartProductDetails).HasForeignKey(cci => cci.ProductDetailsId);
        }
    }
}
