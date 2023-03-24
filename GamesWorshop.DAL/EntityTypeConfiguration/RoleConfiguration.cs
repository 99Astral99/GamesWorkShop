using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role()
                {
                    Id = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7BB0B1"),
                    Name = "User",
                    NormalizedName = "USER"
                });

            builder.HasData(
                new Role()
                {
                    Id = new Guid("FB53FCFE-3B74-4F77-8B9E-E543A38E1BC6"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                });

            builder.HasData(
                new Role()
                {
                    Id = new Guid("2FEFCA10-F3F9-424B-BED4-EC5D810CC619"),
                    Name = "Support",
                    NormalizedName = "SUPPORT",
                });
        }
    }
}
