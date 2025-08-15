using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillTutor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adeee0a6-e793-42fb-a717-4ba9683e8d16", 0, "73786392-52b2-4036-9457-9b9426c567ee", null, false, "Desktop", null, "User", false, null, null, null, "AfC6BAAQFzGft4B8lqbKdGYb5SJSHiKcsSi5PTfHfHLGSzn+fyCD323C0p/e46oiqD5VoFiG", null, false, "2535a0df-73d1-4c88-9119-515ee2ce6c95", false, "desktop" },
                    { "c0d2a196-00cb-4918-a77a-40c5f719ec54", 0, "737a1562-aa35-4f55-8e3b-521938b5c0fc", null, false, "Mobile", null, "User", false, null, null, null, "AfC6BAAQJ081Wi/1TdZ3TVDNxfYu2rUONLxh2dkMcWXasE1AN7bP5wF8FcC2lEG9QaBsoVf3", null, false, "22957d8a-14f6-4630-82aa-3c79a7d468b7", false, "mobile" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adeee0a6-e793-42fb-a717-4ba9683e8d16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0d2a196-00cb-4918-a77a-40c5f719ec54");
        }
    }
}
