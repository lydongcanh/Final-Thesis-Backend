using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerOrderDetailsConfiguration : IConfiguration<CustomerOrderDetails>
    {
        public void Configure(EntityTypeBuilder<CustomerOrderDetails> builder)
        {
            builder.HasKey(cod => new { cod.ProductDetailsId, cod.CustomerOrderId });
            builder.Property(cod => cod.Quantity).IsRequired();
            builder.Property(cod => cod.PurchasedPrice).IsRequired();
            builder.HasOne(cod => cod.ProductDetails).WithMany(pd => pd.CustomerOrderDetails).HasForeignKey(pd => pd.ProductDetailsId);
            builder.HasOne(cod => cod.CustomerOrder).WithMany(co => co.OrderDetails).HasForeignKey(cod => cod.CustomerOrderId);
        }
    }
}
