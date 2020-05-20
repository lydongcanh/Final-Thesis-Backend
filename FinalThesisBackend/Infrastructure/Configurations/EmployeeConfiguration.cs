using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Birthdate).IsRequired();
            builder.Property(e => e.Gender).HasMaxLength(20).IsRequired();
            builder.Property(e => e.JobTitle).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.OwnsOne(e => e.Address, address =>
            {
                address.Property(a => a.Number).HasMaxLength(50);
                address.Property(a => a.Street).HasMaxLength(50);
                address.Property(a => a.District).HasMaxLength(50);
                address.Property(a => a.City).HasMaxLength(50);
            });
            builder.HasOne(e => e.Account).WithOne(a => a.Employee).HasForeignKey<Account>(a => a.EmployeeId);
            builder.HasMany(e => e.OrderStateDetails).WithOne(cosd => cosd.Employee).HasForeignKey(cosd => cosd.EmployeeId);
        }
    }
}
