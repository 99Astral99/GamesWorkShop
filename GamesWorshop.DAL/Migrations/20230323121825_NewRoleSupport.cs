using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesWorshop.DAL.Migrations
{
    public partial class NewRoleSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec274526-d90e-4ecd-bd85-cd84ed7bb0b1"),
                column: "ConcurrencyStamp",
                value: "e0ccd798-9581-436d-8d01-62fb5539b128");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb53fcfe-3b74-4f77-8b9e-e543a38e1bc6"),
                column: "ConcurrencyStamp",
                value: "191858d7-5bb5-4e77-8be4-b2c2d9212899");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2fefca10-f3f9-424b-bed4-ec5d810cc619"), "56e6d240-ba73-4448-9456-c38f2048fae7", "Support", "SUPPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("480a013f-9eb1-4890-b543-3fd416466804"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8b4aa1ee-e32b-4585-a2f2-2e7faa6fcad1", "AQAAAAEAACcQAAAAEK3QB7jpWliocplnkMPwFbbEuH2Yy2nPURHXki6CdvZbAcWwsZzCAWHHjJGRR2fKgA==", "b2b84397-2484-42b8-bc46-f8a714ff5cbf", "Patrick" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "781eda46-a16e-4eb2-9387-98b8ad7ba5bd", "AQAAAAEAACcQAAAAEJsqrLBFY9hykpVRKwipxmFSga6A2qJyaVSVyeoGAV3Ru7xPDedScZQuv5zZlG+bqQ==", "33c0eb4a-5132-4ebc-8fdc-a25b4a6c55fb", "Paul" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d55eea11-f7cd-4af3-b01a-3eff7604083b"), 0, "c211d093-b293-4b6e-a247-fb47a54803ac", "support@gmail.com", false, false, null, "SUPPORT@GMAIL.COM", "TIMOTHY", "AQAAAAEAACcQAAAAEKmu4quCfZcrg+y5jtirIYyoEQioX2bVWMMikIyq5U5/yoN5JqxReWceXeXndSKdyg==", null, false, "088626ed-2b1b-4c29-8a43-969d69681ad3", false, "Timothy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2fefca10-f3f9-424b-bed4-ec5d810cc619"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d55eea11-f7cd-4af3-b01a-3eff7604083b"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec274526-d90e-4ecd-bd85-cd84ed7bb0b1"),
                column: "ConcurrencyStamp",
                value: "4a8b4e52-7bf4-43c9-a15d-4f27c333c010");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb53fcfe-3b74-4f77-8b9e-e543a38e1bc6"),
                column: "ConcurrencyStamp",
                value: "964628ad-bd0d-4fcc-97a1-dddd7cc55db8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("480a013f-9eb1-4890-b543-3fd416466804"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "084d2465-986a-47f9-a1d3-f6964143a72e", "AQAAAAEAACcQAAAAEBM/sYpbScKoLAoO10EuhJ53sj8UhiEoxyZqd6jRIL47EKZUyTFA6+Y9FIkahwp0Cw==", "dc5548c9-49fd-4c53-88a9-b07f024f1069", "PatrickBateman" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec274526-d90e-4ecd-bd85-cd84ed7ae0e9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c01ae625-3c7f-44f4-9c50-94dbf5675a76", "AQAAAAEAACcQAAAAEFBdOxJda6kqH9GK1NqEFtz1OPXtFJVto3ZRXHO0cWAyiTI05slz8mUsEBlKpCyYJw==", "185e0533-397e-4e42-8d57-f98d96fdcc90", "PaulAllen" });
        }
    }
}
