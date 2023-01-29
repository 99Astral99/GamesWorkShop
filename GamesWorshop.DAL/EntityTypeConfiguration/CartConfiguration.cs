using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.ToTable("Carts").HasKey(c => c.Id);

			builder.HasData(new Cart()
			{
				Id = 1,
				UserId = new Guid("480A013F-9EB1-4890-B543-3FD416466804"),
			});

			builder.HasData(new Cart()
			{
				Id = 2,
				UserId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9"),
			});
		}
	}
}
