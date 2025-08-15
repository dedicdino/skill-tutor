using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTutor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNonDeterministicSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adeee0a6-e793-42fb-a717-4ba9683e8d16",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cbf35b86-20cd-451a-9efb-49f5563986ac", "4fc6b3de-3217-4703-a859-2c0b5fc05de0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0d2a196-00cb-4918-a77a-40c5f719ec54",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a63de3a-0640-4477-ba45-ad356bb30bee", "f6cd5f3b-b527-44a5-84a2-fd1eeb334697" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adeee0a6-e793-42fb-a717-4ba9683e8d16",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73786392-52b2-4036-9457-9b9426c567ee", "2535a0df-73d1-4c88-9119-515ee2ce6c95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0d2a196-00cb-4918-a77a-40c5f719ec54",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "737a1562-aa35-4f55-8e3b-521938b5c0fc", "22957d8a-14f6-4630-82aa-3c79a7d468b7" });
        }
    }
}
