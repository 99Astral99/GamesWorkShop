using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Password).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();

            //builder.HasOne(r => r.Role)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(r => r.RoleId);

            builder.HasData(new
            {
                Id = 1,
                Password = "customer",
                Email = "customer@gmail.com",
                Name = "Patrick",
                RoleId = 1,
            });

            builder.HasData(new
            {
                Id = 2,
                Password = "admin",
                Email = "admin@gmail.com",
                Name = "Paul",
                RoleId = 2,
            });
        }
    }
}
