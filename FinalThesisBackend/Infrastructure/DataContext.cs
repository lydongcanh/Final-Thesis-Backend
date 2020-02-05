using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure
{
    public class DataContext: DbContext
    {
        public DbSet<Category> Categories { get; protected set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCategory(modelBuilder.Entity<Category>());
        }

        protected virtual void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.ChildrenCategories)
                   .HasForeignKey(c => c.ParentCategoryId);

            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100);
        }
    }
}
