using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReviewMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewerId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<int>(type: "integer", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "_Review",
                columns: new[] { "Id", "BlogId", "Comment", "DateCreated", "IsResolved", "LastModifiedDate", "ReviewerId" },
                values: new object[,]
                {
                    { 1, 1, "this is the first reveiw", new DateTime(2023, 5, 4, 13, 32, 25, 266, DateTimeKind.Local).AddTicks(3539), false, new DateTime(2023, 5, 4, 13, 32, 25, 266, DateTimeKind.Local).AddTicks(3559), 1 },
                    { 2, 2, "this is the second reveiw", new DateTime(2023, 5, 4, 13, 32, 25, 266, DateTimeKind.Local).AddTicks(3561), false, new DateTime(2023, 5, 4, 13, 32, 25, 266, DateTimeKind.Local).AddTicks(3562), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Review");
        }
    }
}
