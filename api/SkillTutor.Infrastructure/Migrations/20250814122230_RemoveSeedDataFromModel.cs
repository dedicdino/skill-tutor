using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillTutor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedDataFromModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adeee0a6-e793-42fb-a717-4ba9683e8d16", 0, "cbf35b86-20cd-451a-9efb-49f5563986ac", null, false, "Desktop", null, "User", false, null, null, null, "AfC6BAAQFzGft4B8lqbKdGYb5SJSHiKcsSi5PTfHfHLGSzn+fyCD323C0p/e46oiqD5VoFiG", null, false, "4fc6b3de-3217-4703-a859-2c0b5fc05de0", false, "desktop" },
                    { "c0d2a196-00cb-4918-a77a-40c5f719ec54", 0, "6a63de3a-0640-4477-ba45-ad356bb30bee", null, false, "Mobile", null, "User", false, null, null, null, "AfC6BAAQJ081Wi/1TdZ3TVDNxfYu2rUONLxh2dkMcWXasE1AN7bP5wF8FcC2lEG9QaBsoVf3", null, false, "f6cd5f3b-b527-44a5-84a2-fd1eeb334697", false, "mobile" }
                });
        }
    }
}
