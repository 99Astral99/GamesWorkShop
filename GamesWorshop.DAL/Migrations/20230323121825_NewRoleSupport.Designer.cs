﻿// <auto-generated />
using System;
using GamesWorshop.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamesWorshop.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230323121825_NewRoleSupport")]
    partial class NewRoleSupport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = new Guid("480a013f-9eb1-4890-b543-3fd416466804")
                        },
                        new
                        {
                            Id = 2,
                            UserId = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9")
                        });
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "customer@gmail.com",
                            Message = "Hello, I'm curious, when will the \"KV128 Stormsurge\" model be available?",
                            Subject = "Delivery of goods.",
                            UserId = new Guid("480a013f-9eb1-4890-b543-3fd416466804")
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@gmail.com",
                            Message = "Test",
                            Subject = "Test",
                            UserId = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9")
                        });
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CartId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Features")
                        .HasColumnType("text");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7bb0b1"),
                            ConcurrencyStamp = "e0ccd798-9581-436d-8d01-62fb5539b128",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("fb53fcfe-3b74-4f77-8b9e-e543a38e1bc6"),
                            ConcurrencyStamp = "191858d7-5bb5-4e77-8be4-b2c2d9212899",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("2fefca10-f3f9-424b-bed4-ec5d810cc619"),
                            ConcurrencyStamp = "56e6d240-ba73-4448-9456-c38f2048fae7",
                            Name = "Support",
                            NormalizedName = "SUPPORT"
                        });
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("480a013f-9eb1-4890-b543-3fd416466804"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b4aa1ee-e32b-4585-a2f2-2e7faa6fcad1",
                            Email = "customer@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER@GMAIL.COM",
                            NormalizedUserName = "PATRICK",
                            PasswordHash = "AQAAAAEAACcQAAAAEK3QB7jpWliocplnkMPwFbbEuH2Yy2nPURHXki6CdvZbAcWwsZzCAWHHjJGRR2fKgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b2b84397-2484-42b8-bc46-f8a714ff5cbf",
                            TwoFactorEnabled = false,
                            UserName = "Patrick"
                        },
                        new
                        {
                            Id = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "781eda46-a16e-4eb2-9387-98b8ad7ba5bd",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "PAUL",
                            PasswordHash = "AQAAAAEAACcQAAAAEJsqrLBFY9hykpVRKwipxmFSga6A2qJyaVSVyeoGAV3Ru7xPDedScZQuv5zZlG+bqQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "33c0eb4a-5132-4ebc-8fdc-a25b4a6c55fb",
                            TwoFactorEnabled = false,
                            UserName = "Paul"
                        },
                        new
                        {
                            Id = new Guid("d55eea11-f7cd-4af3-b01a-3eff7604083b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c211d093-b293-4b6e-a247-fb47a54803ac",
                            Email = "support@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPPORT@GMAIL.COM",
                            NormalizedUserName = "TIMOTHY",
                            PasswordHash = "AQAAAAEAACcQAAAAEKmu4quCfZcrg+y5jtirIYyoEQioX2bVWMMikIyq5U5/yoN5JqxReWceXeXndSKdyg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "088626ed-2b1b-4c29-8a43-969d69681ad3",
                            TwoFactorEnabled = false,
                            UserName = "Timothy"
                        });
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62b2b25f-a72b-4400-8ef0-4c5aa19f2e24"),
                            Address = "American Gardens Building on W. 81st Street on the 11th floor.",
                            Age = 27,
                            Country = "USA",
                            Email = "customer@gmail.com",
                            FirstName = "Patrick",
                            LastName = "Bateman",
                            UserId = new Guid("480a013f-9eb1-4890-b543-3fd416466804")
                        },
                        new
                        {
                            Id = new Guid("ce0c7610-f567-4ce0-b77b-6898ef016696"),
                            Address = "I have no home",
                            Age = 25,
                            Country = "Russia",
                            Email = "admin@gmail.com",
                            FirstName = "Paul",
                            LastName = "Allen",
                            UserId = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("480a013f-9eb1-4890-b543-3fd416466804"),
                            RoleId = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7bb0b1")
                        },
                        new
                        {
                            UserId = new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9"),
                            RoleId = new Guid("fb53fcfe-3b74-4f77-8b9e-e543a38e1bc6")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Cart", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("GamesWorkshop.Domain.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Contact", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Order", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.UserAccount", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", "User")
                        .WithOne("UserAccount")
                        .HasForeignKey("GamesWorkshop.Domain.Entities.UserAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesWorkshop.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GamesWorkshop.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GamesWorkshop.Domain.Entities.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Contacts");

                    b.Navigation("UserAccount")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
