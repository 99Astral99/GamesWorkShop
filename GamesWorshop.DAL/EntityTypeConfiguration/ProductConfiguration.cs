using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading;

namespace GamesWorshop.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id);
            builder.HasIndex(b => b.CreatedDate);

            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnType("text");
            builder.Property(f => f.Features)
                .HasColumnType("text");

            builder.Property(b => b.Amount).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.ImageSrc).IsRequired();

            builder.HasData(new Product()
            {
                Id = 1,
                Name = "Possesed",
                Description = "Possessed are bestial slaughter incarnate – Astartes warriors merged with fell daemons of the Chaos Gods in a blasphemous union. Warped and mutated by their empyric parasites, the armoured forms of the Possessed flow like wax, shrugging off lethal blows as they manifest talons, snapping maws, and vestigial wings to unleash an unholy orgy of bloodshed.\r\n\r\nThis multipart plastic kit builds five Possessed, monstrous close combat fighters who bear a host of repulsive mutations, from claws and tentacles to bladed limbs. Each model comes with a variety of cosmetic choices – including alternative heads, daemonic limbs, interchangeable backpacks, and other accessories – to ensure that no two models look the same, even within larger units or multiple squads of half-daemon monstrosities. The kit also includes an optional Chaos icon, for a Possessed Champion to invoke the dark blessings of the Ruinous Powers.\r\n\r\nThis set comprises 56 plastic components and is supplied with 5x Citadel 40mm Round Bases. These miniatures are supplied unpainted and require assembly – we recommend using Citadel Plastic Glue and Citadel paints.",
                Features = "Fearsome Elites for Chaos Space Marines\r\nBuilds five Possessed, with a variety of cosmetic options for creating uniquely profane half-daemon Astartes\r\nShred your foes in melee with lashing tentacles, snapping claws, and bladed limbs",
                Price = 45,
                Amount = 20,
                Category = GamesWorkshop.Domain.Enum.Category.ArmiesOfChaos,
                CreatedDate = new DateTime(2022, 05, 19),
                ImageSrc = "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedLead.jpg",
                Image1 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedFeature.jpg",
                Image2 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedSprue1.jpg",
                Image3 = "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120102140_CSMPossessedOTT3360/01-01.jpg",
                Image4 = "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120102140_CSMPossessedOTT2360/01-01.jpg",
                Image5 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedStock.jpg"
            });

            builder.HasData(new Product()
            {
                Id = 2,
                Name = "Mekboy Workshop",
                Description = "All Mekboyz can perform battlefield repairs using no more than a weighty wrench-hammer, a sack of nails and a healthy dose of gumption, but most do their best work in the comfortably anarchic surrounds of their own workshop. Meks are more than capable of cobbling together a workspace from whatever is lying about, with rudimentary workshops springing up from battlefield wreckage even while the bullets are still flying. Greenskin vehicles roar toward such teetering structures, their crews throwing sacks of teef at the resident Mek – he and his crew get to work immediately, sending the Ork customers on their way with snazzier guns, souped-up engines and extra armour plates.\r\n\r\nThis multipart plastic kit contains the components necessary to assemble a Mekboy Workshop. Constructed from metal beams which the industrious Mekboy has salvaged from the clamour of battle around him, the Workshop features a large workbench covered in the gubbinz of his craft – a wall-mounted toolset, an enormous drill, a box of spanners and a vice – and a ton of spare parts. A kustom force field generator, bits of steering wheel, buzzsaw blades; it might look like a random assortment, but the Mekboy who owns it knows exactly where each piece he needs is. A reinforced beam is attached to this workspace at a right angle – a large engine block is hanging from a length of chain, ready for repair or installation, with a large grabbin’ klaw which can be modelled facing in any direction you like. Included are 3 barricades and 3 piles of scrap, which can be placed around the Workshop in any way you like, and the whole kit is compatible with the STC Ryza-pattern Ruins set – build your own kustom sprawling mess!\r\n\r\nThis kit is supplied as 36 components.",
                Features = "An especially Orky scenery piece, the dominion of a crazed Mekboy\r\nAdds more speed, more rivets and more dakka to Ork vehicles in-game\r\nComplete with 3 sets of barricades and a load of scrap!",
                Price = 100,
                Amount = 34,
                Category = GamesWorkshop.Domain.Enum.Category.XenosArmies,
                CreatedDate = new DateTime(2022, 03, 18),
                ImageSrc = "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop01.jpg",
                Image1 = "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120103109_MekboyWorkshopOTT360/01-01.jpg",
                Image2 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop02.jpg",
                Image3 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop03.jpg",
                Image4 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshopTerrain.jpg",
                Image5 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop05.jpg"
            });

            builder.HasData(new Product()
            {
                Id = 3,
                Name = "Space Marines: Honoured of the Chapter",
                Description = "As the Indomitus Crusade spreads across the galaxy, the Primaris Space Marines fight battle after battle, becoming hardened veterans of their Chapters. From the mightiest heroes to the staunchest battle-brothers, each is an honoured warrior whose deeds are legend.\r\n\r\nThis set allows you to add new HQ, Elites, and Heavy Support choices to your Space Marines army. A Primaris Chaplain will enhance the fighting strength of the warriors around him, while a Bladeguard Ancient inspires them to fight on against any odds. The Judiciar can be found in the thick of combat, his great blade cleaving enemy heads. Bladeguard Veterans will join him at the vanguard, their storm shields making them an immovable bulwark. Finally, Eradicators will target the enemy's heaviest armour and bring it down in volleys of melta fire.\r\n\r\nThis 64-piece plastic kit builds 9 Space Marines models:\r\n\r\n– 1x Primaris Chaplain\r\n– 1x Judiciar\r\n– 1x Bladeguard Ancient\r\n– 3x Bladeguard Veterans\r\n– 3x Eradicators\r\n\r\nBoth the Bladeguard Veterans and Eradicators include a Sergeant. The set also includes nine 40mm round bases.\r\n\r\nThe models in this set are push-fit and can be assembled without glue. Rules for them can be found in Codex: Space Marines.",
                Features = "Reinforcements for your Space Marines army Includes three Characters and two squads Available for the first time outside the Indomitus box",
                Amount = 20,
                Price = 120,
                Category = GamesWorkshop.Domain.Enum.Category.SpaceMarines,
                CreatedDate = new DateTime(2022, 09, 12),
                ImageSrc = "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterLead.jpg",
                Image1 = "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120101353_SMHonouredOfTheChapterOTT8360/01-01.jpg",
                Image2 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterFeature2.jpg",
                Image3 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterFeature1.jpg",
                Image4 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterVeteransFeature.jpg",
                Image5 = "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterSprue.jpg"
            });
        }
    }
}
