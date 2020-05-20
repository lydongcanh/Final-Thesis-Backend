using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerOrderConfiguration : IConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.Property(co => co.OrderState).HasMaxLength(50).IsRequired();
            builder.Property(co => co.Description).HasMaxLength(200);
            builder.OwnsOne(co => co.ShipAddress, address =>
            {
                address.Property(a => a.Number).HasMaxLength(50);
                address.Property(a => a.Street).HasMaxLength(50);
                address.Property(a => a.District).HasMaxLength(50);
                address.Property(a => a.City).HasMaxLength(50);
            });
            builder.HasOne(co => co.Customer).WithMany(c => c.Orders).HasForeignKey(co => co.CustomerId);
            builder.HasMany(co => co.OrderDetails).WithOne(od => od.CustomerOrder).HasForeignKey(od => od.CustomerOrderId);
            builder.HasMany(co => co.StateDetails).WithOne(cosd => cosd.CustomerOrder).HasForeignKey(cosd => cosd.CustomerOrderId);
        }
    }
}
