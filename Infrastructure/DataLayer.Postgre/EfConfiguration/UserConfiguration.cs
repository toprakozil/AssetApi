using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Postgre.EfConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(cb => cb.UserName).IsRequired().HasMaxLength(100);
            builder.Property(cb => cb.Name).IsRequired().HasMaxLength(100);
            builder.Property(cb => cb.LastName).HasMaxLength(100);
            builder.Property(cb => cb.Email).HasMaxLength(100);
            builder.Property(cb => cb.DateOfBirth);
            builder.Property(cb => cb.PhoneNumber);
            builder.Property(cb => cb.Password).IsRequired().HasMaxLength(100);

        }
    }
}
