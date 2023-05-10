using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class testIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51ae5874-509d-4c05-9377-be8f219f7543", "AQAAAAIAAYagAAAAEDu0gV2GEgTZNQrc648C9qNPDEMzlBoYSN3YKk/tGnfVdjazuDh5hkyE+t8xaV+vLA==", "308d4a00-713d-41f9-a043-99275f7e25c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e5ab19e-438b-4d0b-aa0c-4a5f677a05a1", "AQAAAAIAAYagAAAAEKEc03f4lBUHQH/9h055GKzPPM2suTPxhkWVjuQ0gdBoZWm+RsueDddoFoF6O8MTIw==", "0b4986a5-564c-4382-91c1-b331f9e66af8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "321ecfe6-aab5-4781-bb14-572c44ed87a9", "AQAAAAIAAYagAAAAEMzhl8X9TRM3Sx1k0sSKN6O7Aya6l1hLddjjLHdp1EThdieY9Z5R5hUVHFFcbS24KQ==", "d40682bb-4f1c-4576-a27f-4317d4476fe9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39d014f0-9ff0-4d79-837e-90241d894ab1", "AQAAAAIAAYagAAAAEKh8NWM0TQUJIP0GQ3pitGWnooXq1d0XfLqLCuBOuderCFnrbuLg9GX/WN7Ewhm6/Q==", "bbf55727-9695-4ff6-87ea-24c3d525aaac" });
        }
    }
}
