using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            //builder.HasMany(u => u.Users)
            //    .WithOne(x => x.Role)
            //    .HasForeignKey(x => x.RoleId);


            //builder.HasData(
            //    new Role()
            //    {
            //        Id = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7BB0B1"),
            //        Name = "User",
            //        NormalizedName = "USER"
            //    });

            //builder.HasData(
            //    new Role()
            //    {
            //        Id = new Guid("EC274526-D90E-4ECD-BD85-CD84EDF4E0C5"),
            //        Name = "Admin",
            //        NormalizedName = "ADMIN",
            //    });
        }
    }
}
