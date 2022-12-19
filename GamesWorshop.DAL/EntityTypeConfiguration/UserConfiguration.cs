using GamesWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.Email).IsUnique();

            //builder.HasOne(r => r.Role)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(r => r.RoleId).IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.UserAccount)
                .WithOne(u => u.User).
                HasForeignKey<UserAccount>(u => u.UserId);


            var user = new User()
            {
                Id = new Guid("480A013F-9EB1-4890-B543-3FD416466804"),
                Email = "customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                UserName = "AmericanPsycho",
                FirstName = "Patrick",
                LastName = "Bateman",
                NormalizedUserName = "PATRICK",
                //RoleId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7BB0B1"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "Patrick Bateman");
            user.PasswordHash = hashed;
            builder.HasData(user);

            var user2 = new User()
            {
                Id = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9"),
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "PaulAllen",
                FirstName = "Paul",
                LastName = "Allen",
                NormalizedUserName = "PAUL",
                //RoleId = new Guid("EC274526-D90E-4ECD-BD85-CD84EDF4E0C5"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password2 = new PasswordHasher<User>();
            var hashed2 = password2.HashPassword(user2, "Paul Allen");
            user2.PasswordHash = hashed2;
            builder.HasData(user2);
        }
    }
}
