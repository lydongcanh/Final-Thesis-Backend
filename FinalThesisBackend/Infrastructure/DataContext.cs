using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Infrastructure.Configurations;

namespace FinalThesisBackend.Infrastructure
{
    public class DataContext: DbContext
    {
        public DbSet<ProductCategory> Categories { get; private set; }
        public DbSet<Account> Accounts { get; private set; }
        public DbSet<Employee> Employees { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Product> Products { get; private set; }
        public DbSet<ProductDetails> ProductDetails { get; private set; }
        public DbSet<CustomerCartItem> CustomerCartItems { get; private set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configure(new ProductCategoryConfiguration(), modelBuilder.Entity<ProductCategory>());
            Configure(new AccountConfiguration(), modelBuilder.Entity<Account>());
            Configure(new EmployeeConfiguration(), modelBuilder.Entity<Employee>());
            Configure(new CustomerConfiguration(), modelBuilder.Entity<Customer>());
            Configure(new ProductConfiguration(), modelBuilder.Entity<Product>());
            Configure(new ProductDetailsConfiguration(), modelBuilder.Entity<ProductDetails>());
            Configure(new CustomerCartItemConfiguration(), modelBuilder.Entity<CustomerCartItem>());
        }

        private void Configure<T>(IConfiguration<T> configuration, EntityTypeBuilder<T> builder) where T: class
        {
            configuration.Configure(builder);
        }
    }
}
