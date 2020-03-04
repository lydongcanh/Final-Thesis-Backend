using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure
{
    public class DataContext: DbContext
    {
        public DbSet<Category> Categories { get; protected set; }
        public DbSet<Account> Accounts { get; protected set; }
        public DbSet<Employee> Employees { get; protected set; }
        public DbSet<Customer> Customers { get; protected set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCategory(modelBuilder.Entity<Category>());
            CongifureAccount(modelBuilder.Entity<Account>());
            ConfigureEmployee(modelBuilder.Entity<Employee>());
            ConfigureCustomer(modelBuilder.Entity<Customer>());
        }

        protected virtual void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100);
            builder.HasOne(c => c.ParentCategory).WithMany(c => c.ChildrenCategories).HasForeignKey(c => c.ParentCategoryId);
        }

        protected virtual void CongifureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Username).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(100).IsRequired();
            builder.Property(a => a.AccountType).HasMaxLength(20).IsRequired();
            builder.HasOne(a => a.Customer).WithOne(c => c.Account).HasForeignKey<Account>(a => a.CustomerId);
            builder.HasOne(a => a.Employee).WithOne(e => e.Account).HasForeignKey<Account>(a => a.EmployeeId);
        }

        protected virtual void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
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

        protected virtual void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Gender).HasMaxLength(20);
            builder.Property(c => c.VipLevel).HasMaxLength(20);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.HasOne(c => c.Account).WithOne(a => a.Customer).HasForeignKey<Customer>(c => c.AccountId);
        }
    }
}
