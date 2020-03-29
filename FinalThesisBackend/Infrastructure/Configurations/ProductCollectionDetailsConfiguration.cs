using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public class ProductCollectionDetailsConfiguration : IConfiguration<ProductCollectionDetails>
    {
        public void Configure(EntityTypeBuilder<ProductCollectionDetails> builder)
        {
            builder.Ignore(pcd => pcd.Id);
            builder.HasKey(pcd => new { pcd.ProductId, pcd.ProductCollectionId });
        }
    }
}
