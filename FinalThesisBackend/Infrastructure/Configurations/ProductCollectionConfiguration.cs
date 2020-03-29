using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class ProductCollectionConfiguration : IConfiguration<ProductCollection>
    {
        public void Configure(EntityTypeBuilder<ProductCollection> builder)
        {
            builder.Property(pc => pc.Name).HasMaxLength(100).IsRequired();
            builder.Property(pc => pc.CreationDate).HasDefaultValue(DateTime.Now);
            builder.HasMany(pc => pc.Details).WithOne(pcd => pcd.ProductCollection).HasForeignKey(pcd => pcd.ProductCollectionId);
        }
    }
}
