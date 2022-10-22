using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Description).HasMaxLength(200);

            builder.Property(b => b.Amount).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.Category).IsRequired();
        }
    }
}
