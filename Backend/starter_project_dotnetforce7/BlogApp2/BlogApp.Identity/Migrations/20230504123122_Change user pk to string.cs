using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Changeuserpktostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6123c26ebf21e81f7ccf9383");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6123c291bf21e81f7ccf9384");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e6c52d57-24b6-4524-be10-eb7bce4d3217", 0, "01b9f6f7-9282-466b-8709-dd756969e368", "admin@localhost.com", true, "Admin", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAIAAYagAAAAEM850RZDeuf/T6OrePfGTxutqivbKfqfT4nGt6zFj8l/SDLurE45QFByxyfWBIKeFw==", null, false, "e7f18583-0d93-4cfd-b502-445252f1161b", false, "Admin" },
                    { "fb8656da-2b94-474f-8709-85e0cd7ea903", 0, "24b110fa-8062-4578-b25d-f05585113f66", "user@localhost.com", true, "User", "User", false, null, "USER@LOCALHOST.COM", "USER", "AQAAAAIAAYagAAAAED8M/vTvo3hqJspu/dxNpQkJDg3KU6XvlASyWwV2OBazuY8flcKGDdb6HtPAIf7anA==", null, false, "71a35cee-18eb-4844-b91c-d9e917c6259c", false, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6c52d57-24b6-4524-be10-eb7bce4d3217");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb8656da-2b94-474f-8709-85e0cd7ea903");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6123c26ebf21e81f7ccf9383", 0, "634bec3e-bc9b-405b-9663-70a08a9dfefd", "admin@localhost.com", true, "Admin", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAIAAYagAAAAEHI+LmytVyZdC7BJH6mVDpk0YB4Cdvwrr+kwN2pZ8Stv3f/UqlLOQCcrh2rsFHvnvg==", null, false, "ec54a9f9-371a-4a0e-a9d6-c7b099dec83c", false, "Admin" },
                    { "6123c291bf21e81f7ccf9384", 0, "1c99c6a4-9405-4ad1-a3f9-c109610f3956", "user@localhost.com", true, "User", "User", false, null, "USER@LOCALHOST.COM", "USER", "AQAAAAIAAYagAAAAEDb3PGspMm+8NaWzdjMazt9Ck7WosBLlcKwx1K5qtzSt/fxTVdX+xiWHJDmdrqFxZg==", null, false, "8fdecb20-6569-4c3f-a217-7ac2f3488d0e", false, "User" }
                });
        }
    }
}
