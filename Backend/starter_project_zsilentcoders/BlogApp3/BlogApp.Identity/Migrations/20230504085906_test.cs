using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Identity.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51aa4c19-c079-4beb-b223-f3b2b6d3d71c",
                column: "ConcurrencyStamp",
                value: "2fb2df1f-9390-4efd-a681-597c59cf4ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9b1000b-3331-4e6d-8777-cc1251eb68d6",
                column: "ConcurrencyStamp",
                value: "99f3fd42-381f-432a-9bae-1594b707d2dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4000b844-74ca-479b-badb-4f41850ae07e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076df84e-342b-4b4b-a252-9c4bdce7f9f0", "AQAAAAEAACcQAAAAEOKlI1IGEia2f7Kd0mhZXXhYAYrGH+9lC7l9jG6/Wj1cIgIhwxxMnGwfpDvjeOblnA==", "bffc326b-947f-4f94-82de-e5e3530bc91b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efa06a55-d0cc-4e01-abbf-870f21d91441",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "523af4d0-cb3a-43ba-93c9-09d1ae7938b3", "AQAAAAEAACcQAAAAEIkVKkkQ1UcsZf22TNlBFpRcCMlVmd/vu/JW2Xw5gNyhpWfKEznQS6Xt2TaTV8lILw==", "0c7c40f0-996c-4d7f-a8f8-1310fe7bf411" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51aa4c19-c079-4beb-b223-f3b2b6d3d71c",
                column: "ConcurrencyStamp",
                value: "b63039fa-31a2-426b-972c-6cdd6d9e409b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9b1000b-3331-4e6d-8777-cc1251eb68d6",
                column: "ConcurrencyStamp",
                value: "1a24b2ec-3b70-40f7-bd2f-17b96ffb4b39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4000b844-74ca-479b-badb-4f41850ae07e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf95aaca-85f1-4828-8e5c-61cb92ef0e22", "AQAAAAEAACcQAAAAENRZ3z4ERuhHuPPBxhq8lve5VFTI6AMj/4l6kJAIrIxjZ3xx4f1NeKcmLyrvpVz6cw==", "39253c61-f940-42a3-b0ab-223bbd7a2984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efa06a55-d0cc-4e01-abbf-870f21d91441",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "743e7649-0b71-489d-8495-6eea4b2c5802", "AQAAAAEAACcQAAAAEM3Pfd0zDPJXKuzKyL5F7rs2wWi9bzcX9GJQHEF/+ODSFvD2BB8FVTITJg+qM6YzzA==", "30f75900-c7f2-4c76-b55d-e351a2343edd" });
        }
    }
}
