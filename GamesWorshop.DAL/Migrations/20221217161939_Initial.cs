using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesWorshop.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("480a013f-9eb1-4890-b543-3fd416466804"), 0, "02ddc17d-2187-476b-bda2-eb6b922aee13", "customer@gmail.com", false, "Patrick", "Bateman", false, null, "CUSTOMER@GMAIL.COM", "PATRICK", "AQAAAAEAACcQAAAAEBEBXjBG2RUvwDtj3d260n8zvYIvGE1v0F4Q1QQrbF25qrDkdXYbOwdjAF3wNWhn7w==", null, false, "f40674c2-42dc-4616-ba8c-bf068da86fc5", false, "AmericanPsycho" },
                    { new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9"), 0, "7413657b-acc3-4961-90f4-920eae4994fb", "admin@gmail.com", false, "Paul", "Allen", false, null, "ADMIN@GMAIL.COM", "PAUL", "AQAAAAEAACcQAAAAEAC3iQm/KDha/Mt1m56nqSyRdyf//g/rZDl+QioyIzgBj++2AYxNRP1av1+vWmuMbA==", null, false, "ccfe79e0-468c-4de2-9e2c-859cd9a75403", false, "PaulAllen" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Category", "CreatedDate", "Description", "Features", "Image1", "Image2", "Image3", "Image4", "Image5", "ImageSrc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 20, 2, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possessed are bestial slaughter incarnate – Astartes warriors merged with fell daemons of the Chaos Gods in a blasphemous union. Warped and mutated by their empyric parasites, the armoured forms of the Possessed flow like wax, shrugging off lethal blows as they manifest talons, snapping maws, and vestigial wings to unleash an unholy orgy of bloodshed.\r\n\r\nThis multipart plastic kit builds five Possessed, monstrous close combat fighters who bear a host of repulsive mutations, from claws and tentacles to bladed limbs. Each model comes with a variety of cosmetic choices – including alternative heads, daemonic limbs, interchangeable backpacks, and other accessories – to ensure that no two models look the same, even within larger units or multiple squads of half-daemon monstrosities. The kit also includes an optional Chaos icon, for a Possessed Champion to invoke the dark blessings of the Ruinous Powers.\r\n\r\nThis set comprises 56 plastic components and is supplied with 5x Citadel 40mm Round Bases. These miniatures are supplied unpainted and require assembly – we recommend using Citadel Plastic Glue and Citadel paints.", "Fearsome Elites for Chaos Space Marines\r\nBuilds five Possessed, with a variety of cosmetic options for creating uniquely profane half-daemon Astartes\r\nShred your foes in melee with lashing tentacles, snapping claws, and bladed limbs", "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedFeature.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedSprue1.jpg", "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120102140_CSMPossessedOTT3360/01-01.jpg", "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120102140_CSMPossessedOTT2360/01-01.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedStock.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120102140_CSMPossessedLead.jpg", "Possesed", 45.0 },
                    { 2, 34, 3, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "All Mekboyz can perform battlefield repairs using no more than a weighty wrench-hammer, a sack of nails and a healthy dose of gumption, but most do their best work in the comfortably anarchic surrounds of their own workshop. Meks are more than capable of cobbling together a workspace from whatever is lying about, with rudimentary workshops springing up from battlefield wreckage even while the bullets are still flying. Greenskin vehicles roar toward such teetering structures, their crews throwing sacks of teef at the resident Mek – he and his crew get to work immediately, sending the Ork customers on their way with snazzier guns, souped-up engines and extra armour plates.\r\n\r\nThis multipart plastic kit contains the components necessary to assemble a Mekboy Workshop. Constructed from metal beams which the industrious Mekboy has salvaged from the clamour of battle around him, the Workshop features a large workbench covered in the gubbinz of his craft – a wall-mounted toolset, an enormous drill, a box of spanners and a vice – and a ton of spare parts. A kustom force field generator, bits of steering wheel, buzzsaw blades; it might look like a random assortment, but the Mekboy who owns it knows exactly where each piece he needs is. A reinforced beam is attached to this workspace at a right angle – a large engine block is hanging from a length of chain, ready for repair or installation, with a large grabbin’ klaw which can be modelled facing in any direction you like. Included are 3 barricades and 3 piles of scrap, which can be placed around the Workshop in any way you like, and the whole kit is compatible with the STC Ryza-pattern Ruins set – build your own kustom sprawling mess!\r\n\r\nThis kit is supplied as 36 components.", "An especially Orky scenery piece, the dominion of a crazed Mekboy\r\nAdds more speed, more rivets and more dakka to Ork vehicles in-game\r\nComplete with 3 sets of barricades and a load of scrap!", "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120103109_MekboyWorkshopOTT360/01-01.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop02.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop03.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshopTerrain.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop05.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120103061_OrkMekWorkshop01.jpg", "Mekboy Workshop", 100.0 },
                    { 3, 20, 0, new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "As the Indomitus Crusade spreads across the galaxy, the Primaris Space Marines fight battle after battle, becoming hardened veterans of their Chapters. From the mightiest heroes to the staunchest battle-brothers, each is an honoured warrior whose deeds are legend.\r\n\r\nThis set allows you to add new HQ, Elites, and Heavy Support choices to your Space Marines army. A Primaris Chaplain will enhance the fighting strength of the warriors around him, while a Bladeguard Ancient inspires them to fight on against any odds. The Judiciar can be found in the thick of combat, his great blade cleaving enemy heads. Bladeguard Veterans will join him at the vanguard, their storm shields making them an immovable bulwark. Finally, Eradicators will target the enemy's heaviest armour and bring it down in volleys of melta fire.\r\n\r\nThis 64-piece plastic kit builds 9 Space Marines models:\r\n\r\n– 1x Primaris Chaplain\r\n– 1x Judiciar\r\n– 1x Bladeguard Ancient\r\n– 3x Bladeguard Veterans\r\n– 3x Eradicators\r\n\r\nBoth the Bladeguard Veterans and Eradicators include a Sergeant. The set also includes nine 40mm round bases.\r\n\r\nThe models in this set are push-fit and can be assembled without glue. Rules for them can be found in Codex: Space Marines.", "Reinforcements for your Space Marines army Includes three Characters and two squads Available for the first time outside the Indomitus box", "https://www.games-workshop.com/resources/catalog/product/threeSixty/99120101353_SMHonouredOfTheChapterOTT8360/01-01.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterFeature2.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterFeature1.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterVeteransFeature.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterSprue.jpg", "https://www.games-workshop.com/resources/catalog/product/920x950/99120101353_HonouredoftheChapterLead.jpg", "Space Marines: Honoured of the Chapter", 120.0 }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Address", "Age", "Country", "Email", "Name", "UserId" },
                values: new object[] { new Guid("62b2b25f-a72b-4400-8ef0-4c5aa19f2e24"), "I have no home", 27, "USA", "customer@gmail.com", "Patrick", new Guid("480a013f-9eb1-4890-b543-3fd416466804") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Address", "Age", "Country", "Email", "Name", "UserId" },
                values: new object[] { new Guid("ce0c7610-f567-4ce0-b77b-6898ef016696"), "I have no home", 25, "Russia", "admin@gmail.com", "Paul", new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedDate",
                table: "Products",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
