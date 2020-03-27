using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Configurations
{
    public interface IConfiguration<T> where T: class
    {
        public void Configure(EntityTypeBuilder<T> builder);
    }
}
