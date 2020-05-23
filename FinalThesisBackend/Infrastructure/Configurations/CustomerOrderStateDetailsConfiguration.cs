using System;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerOrderStateDetailsConfiguration : IConfiguration<CustomerOrderStateDetails>
    {
        public void Configure(EntityTypeBuilder<CustomerOrderStateDetails> builder)
        {
            builder.HasKey(cosd => new { cosd.CustomerOrderId, cosd.OrderState });
            builder.Ignore(cosd => cosd.Id);
            builder.Property(cosd => cosd.OrderState).HasMaxLength(50).IsRequired();
            builder.Property(cosd => cosd.Description).HasMaxLength(200);
            builder.Property(cosd => cosd.CreationDate).HasDefaultValue(DateTime.Now);
            builder.HasOne(cosd => cosd.CustomerOrder).WithMany(co => co.StateDetails).HasForeignKey(cosd => cosd.CustomerOrderId);
            builder.HasOne(cosd => cosd.Employee).WithMany(e => e.OrderStateDetails).HasForeignKey(cosd => cosd.EmployeeId);
        }
    }
}
