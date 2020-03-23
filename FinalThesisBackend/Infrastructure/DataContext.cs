using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Infrastructure.Configurations;

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
            Configure(new CategoryConfiguration(), modelBuilder.Entity<Category>());
            Configure(new AccountConfiguration(), modelBuilder.Entity<Account>());
            Configure(new EmployeeConfiguration(), modelBuilder.Entity<Employee>());
            Configure(new CustomerConfiguration(), modelBuilder.Entity<Customer>());
        }

        protected void Configure<T>(IConfiguration<T> configuration, EntityTypeBuilder<T> builder) where T: BaseEntity
        {
            configuration.Configure(builder);
        }
    }
}
