using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "CreatedAt", "PlatformId", "UpdatedAt", "Url", "UserId" },
                values: new object[] { new Guid("ca4d5b3d-4144-4c70-92bc-501e7fc988a4"), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1350), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1350), "https://github.com/Heba-WebDev", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "BaseUrl", "Color", "CreatedAt", "Image", "IsSupported", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "https://www.youtube.com", "#EE3939", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1280), "/images/platforms/youtube.svg", true, "Youtube", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1280) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "http://linkedin.com", "#2D68FF", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300), "/images/platforms/linkedin.svg", true, "Linkedin", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "https://github.com", "#1A1A1A", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300), "/images/platforms/github.svg", true, "Github", new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Image", "LastName", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 8, 23, 9, 56, 19, 519, DateTimeKind.Utc).AddTicks(1070), "john@example.com", "John", null, "Doe", "$2a$11$mwrZb.Q1sFk//6OPFfOOCuWopWZV0LbSMfJsJR2tihLgTOPoVqN7S", 0, new DateTime(2024, 8, 23, 9, 56, 19, 519, DateTimeKind.Utc).AddTicks(1070), "john23" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 8, 23, 9, 56, 19, 749, DateTimeKind.Utc).AddTicks(6710), "susi@example.com", "Susi", null, "Jr", "$2a$11$wu2xC6V2rtBU4rNsVBf17e5TPE0EeUntmlwruH5x5PwUXrhYjx1hy", 1, new DateTime(2024, 8, 23, 9, 56, 19, 749, DateTimeKind.Utc).AddTicks(6710), "susi11" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: new Guid("ca4d5b3d-4144-4c70-92bc-501e7fc988a4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
