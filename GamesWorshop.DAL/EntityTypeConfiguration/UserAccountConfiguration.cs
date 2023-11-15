using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(u => u.Address).HasMaxLength(300);

            builder.HasData(new UserAccount()
            {
                Id = new Guid("62B2B25F-A72B-4400-8EF0-4C5AA19F2E24"),
                UserId = new Guid("480A013F-9EB1-4890-B543-3FD416466804"),
                Country = "USA",
                Email = "customer@gmail.com",
                Address = "American Gardens Building on W. 81st Street on the 11th floor.",
                FirstName = "Patrick",
                LastName = "Bateman",
                Age = 27
            });

            builder.HasData(new UserAccount()
            {
                Id = new Guid("CE0C7610-F567-4CE0-B77B-6898EF016696"),
                UserId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9"),
                Country = "Russia",
                Email = "admin@gmail.com",
                Address = "I have no home",
                FirstName = "Paul",
                LastName = "Allen",
                Age = 25
            });
        }
    }
}
