using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerConfiguration : IConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Gender).HasMaxLength(20);
            builder.Property(c => c.VipLevel).HasMaxLength(20);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(a => a.Number).HasMaxLength(50);
                address.Property(a => a.Street).HasMaxLength(50);
                address.Property(a => a.District).HasMaxLength(50);
                address.Property(a => a.City).HasMaxLength(50);
            });
            builder.HasOne(c => c.Account).WithOne(a => a.Customer).HasForeignKey<Account>(a => a.CustomerId);
            builder.HasMany(c => c.CartItems).WithOne(ci => ci.Customer).HasForeignKey(ci => ci.CustomerId);
        }
    }
}
