using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class CustomerProductDetailsConfiguration : IConfiguration<CustomerProductDetails>
    {
        public void Configure(EntityTypeBuilder<CustomerProductDetails> builder)
        {
            builder.HasKey(cpd => new { cpd.CustomerId, cpd.ProductId });
            builder.Ignore(cpd => cpd.Id);
            builder.HasOne(cpd => cpd.Customer).WithMany(c => c.CustomerProductDetails).HasForeignKey(cpd => cpd.CustomerId);
            builder.HasOne(cpd => cpd.Product).WithMany(p => p.CustomerProductDetails).HasForeignKey(cpd => cpd.ProductId);
        }
    }
}
