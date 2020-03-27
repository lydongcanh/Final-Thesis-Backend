using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CartConfiguration : IConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasOne(c => c.Customer).WithOne(c => c.Cart).HasForeignKey<Customer>(c => c.CartId);
            builder.HasMany(c => c.CartProductDetails).WithOne(cpd => cpd.Cart).HasForeignKey(cpd => cpd.CartId);
        }
    }
}
