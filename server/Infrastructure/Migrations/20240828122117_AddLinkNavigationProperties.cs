using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: new Guid("ca4d5b3d-4144-4c70-92bc-501e7fc988a4"));

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "CreatedAt", "PlatformId", "UpdatedAt", "Url", "UserId" },
                values: new object[] { new Guid("21e32ac1-a80b-4769-99f0-ee48671a07d7"), new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2850), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2850), "https://github.com/Heba-WebDev", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2790), new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810), new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810), new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 12, 21, 16, 910, DateTimeKind.Utc).AddTicks(3330), "$2a$11$lWKtrkGZayyS8X7YPEKve.ZHH0fEgQMBw7kfWgQmolxFRDPSf6DtW", new DateTime(2024, 8, 28, 12, 21, 16, 910, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 12, 21, 17, 138, DateTimeKind.Utc).AddTicks(4950), "$2a$11$iByeG04Vdb4oJQiD9jlIou3ENz9tipxgMPhu/00FYyU3dlR8ZXAha", new DateTime(2024, 8, 28, 12, 21, 17, 138, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PlatformId",
                table: "Links",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Platforms_PlatformId",
                table: "Links",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Platforms_PlatformId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PlatformId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_UserId",
                table: "Links");

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: new Guid("21e32ac1-a80b-4769-99f0-ee48671a07d7"));

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "CreatedAt", "PlatformId", "UpdatedAt", "Url", "UserId" },
                values: new object[] { new Guid("ca4d5b3d-4144-4c70-92bc-501e7fc988a4"), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1350), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1350), "https://github.com/Heba-WebDev", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1280), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300), new DateTime(2024, 8, 23, 9, 56, 19, 979, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 56, 19, 519, DateTimeKind.Utc).AddTicks(1070), "$2a$11$mwrZb.Q1sFk//6OPFfOOCuWopWZV0LbSMfJsJR2tihLgTOPoVqN7S", new DateTime(2024, 8, 23, 9, 56, 19, 519, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 56, 19, 749, DateTimeKind.Utc).AddTicks(6710), "$2a$11$wu2xC6V2rtBU4rNsVBf17e5TPE0EeUntmlwruH5x5PwUXrhYjx1hy", new DateTime(2024, 8, 23, 9, 56, 19, 749, DateTimeKind.Utc).AddTicks(6710) });
        }
    }
}
