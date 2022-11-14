using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.RoleName).IsRequired();
            builder.HasData(
                new
                {
                    RoleId = 1,
                    RoleName = "Customer"
                });

            builder.HasData(
                new
                {
                    RoleId = 2,
                    RoleName = "Admin"
                });
        }
    }
}
