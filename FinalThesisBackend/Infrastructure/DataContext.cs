using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Infrastructure.Configurations;

namespace FinalThesisBackend.Infrastructure
{
    public class DataContext: DbContext
    {
        public DbSet<Account> Accounts { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<CustomerCartItem> CustomerCartItems { get; private set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public DbSet<Employee> Employees { get; private set; }
        public DbSet<Product> Products { get; private set; }
        public DbSet<ProductCategory> Categories { get; private set; }
        public DbSet<ProductCollection> ProductCollections { get; private set; }
        public DbSet<ProductCollectionDetails> ProductCollectionDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; private set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configure(new AccountConfiguration(), modelBuilder.Entity<Account>());
            Configure(new CustomerConfiguration(), modelBuilder.Entity<Customer>());
            Configure(new CustomerCartItemConfiguration(), modelBuilder.Entity<CustomerCartItem>());
            Configure(new CustomerOrderConfiguration(), modelBuilder.Entity<CustomerOrder>());
            Configure(new CustomerOrderDetailsConfiguration(), modelBuilder.Entity<CustomerOrderDetails>());
            Configure(new EmployeeConfiguration(), modelBuilder.Entity<Employee>());
            Configure(new ProductConfiguration(), modelBuilder.Entity<Product>());
            Configure(new ProductCategoryConfiguration(), modelBuilder.Entity<ProductCategory>());
            Configure(new ProductCollectionConfiguration(), modelBuilder.Entity<ProductCollection>());
            Configure(new ProductCollectionDetailsConfiguration(), modelBuilder.Entity<ProductCollectionDetails>());
            Configure(new ProductDetailsConfiguration(), modelBuilder.Entity<ProductDetails>());
        }

        private void Configure<T>(IConfiguration<T> configuration, EntityTypeBuilder<T> builder) where T: class
        {
            configuration.Configure(builder);
        }
    }
}
