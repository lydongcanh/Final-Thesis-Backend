using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class AccountConfiguration : IConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Username).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(200);
            builder.Property(a => a.AccountType).HasMaxLength(20).IsRequired();
            builder.HasOne(a => a.Customer).WithOne(c => c.Account).HasForeignKey<Account>(a => a.CustomerId);
            builder.HasOne(a => a.Employee).WithOne(e => e.Account).HasForeignKey<Account>(a => a.EmployeeId);
        }
    }
}
