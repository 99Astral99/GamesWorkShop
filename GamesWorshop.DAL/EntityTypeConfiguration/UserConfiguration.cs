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

            builder.HasOne(u => u.UserAccount)
                .WithOne(u => u.User).
                HasForeignKey<UserAccount>(u => u.UserId)
               .OnDelete(DeleteBehavior.Cascade); 


            builder.HasOne(u => u.Cart)
                .WithOne(x => x.User)
                .HasPrincipalKey<User>(x=>x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            var user = new User()
            {
                Id = new Guid("480A013F-9EB1-4890-B543-3FD416466804"),
                Email = "customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                UserName = "Patrick",
                NormalizedUserName = "PATRICK",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "defaultpassword");
            user.PasswordHash = hashed;
            builder.HasData(user);

            var admin = new User()
            {
                Id = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9"),
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "Paul",
                NormalizedUserName = "PAUL",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var password2 = new PasswordHasher<User>();
            var hashed2 = password2.HashPassword(admin, "defaultpassword");
            admin.PasswordHash = hashed2;
            builder.HasData(admin);

            var support = new User()
            {
                Id = new Guid("D55EEA11-F7CD-4AF3-B01A-3EFF7604083B"),
                Email = "support@gmail.com",
                NormalizedEmail = "SUPPORT@GMAIL.COM",
                UserName = "Timothy",
                NormalizedUserName = "TIMOTHY",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var password3 = new PasswordHasher<User>();
            var hashed3 = password3.HashPassword(support, "defaultpassword");
            support.PasswordHash = hashed3;
            builder.HasData(support);
        }
    }
}
