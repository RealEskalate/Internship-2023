using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class testUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "245178ab-1987-45f8-b77a-a17dba5d85fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "209ceca6-d602-4595-979c-87ac598c9dac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a54a6e9e-34f4-4c4b-a5a3-ca25a73d9793", "AQAAAAEAACcQAAAAEGqUgW9ZiHivUoEQslxOKms9PQDLhdGR5+5D2v/XNJoA6ihL/+Iu1KYx1Ha11ghbSA==", "35273815-2f2f-48d4-96b0-a65a35151eff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a92f3c12-94e2-4335-983c-0a9e0c561620", "AQAAAAEAACcQAAAAEIFuRaKFbsKdyZguEq7BiUJd/9hhoul4MEFC0DzumX670JN201j4R+JXoChkdzUfnQ==", "24ee61b0-ff22-4d3b-acb4-53c5bcaac6fc" });
        }
    }
}
