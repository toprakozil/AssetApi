using Domain.Asset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Postgre.EfConfiguration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.Property(cb => cb.Name).IsRequired().HasMaxLength(100);
            builder.Property(cb => cb.MacAddress).IsRequired();
            builder.Property(cb => cb.CategoryId);
            builder.Property(cb => cb.StatusId);
        }
    }
}
