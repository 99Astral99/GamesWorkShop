using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesWorshop.DAL.EntityTypeConfiguration
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable("Contacts").HasKey(i => i.Id);

			builder.HasOne(u => u.User)
				.WithMany(c => c.Contacts)
				.HasForeignKey(i => i.UserId);

			builder.HasData(new Contact()
			{
				Id = 1,
				Email = "customer@gmail.com",
				Subject = "Delivery of goods.",
				Message= "Hello, I'm curious, when will the \"KV128 Stormsurge\" model be available?",
				UserId = new Guid("480A013F-9EB1-4890-B543-3FD416466804")
			});

			builder.HasData(new Contact()
			{
				Id = 2,
				Email = "admin@gmail.com",
				Subject = "Test",
				Message = "Test",
				UserId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9")
			});
		}
	}
}
