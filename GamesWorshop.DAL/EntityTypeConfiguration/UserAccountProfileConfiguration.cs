using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
    public class UserAccountProfileConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(u => u.Address).HasMaxLength(300);
        }
    }
}
