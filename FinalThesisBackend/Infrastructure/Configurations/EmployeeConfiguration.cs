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
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Gender).HasMaxLength(20).IsRequired();
            builder.Property(e => e.JobTitle).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.HasOne(e => e.Account).WithOne(a => a.Employee).HasForeignKey<Employee>(e => e.AccountId);
        }
    }
}
