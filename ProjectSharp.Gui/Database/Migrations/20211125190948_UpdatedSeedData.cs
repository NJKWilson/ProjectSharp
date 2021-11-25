using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSharp.DataAccess.Migrations
{
    public partial class UpdatedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9b04a46-f520-4682-94fd-d510239c5920"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Email", "Password", "Role", "UpdatedById", "UpdatedOn" },
                values: new object[] { new Guid("6f3fb42f-69ba-4b24-9b26-a43b5986db4a"), null, new DateTimeOffset(new DateTime(2021, 11, 25, 19, 9, 48, 363, DateTimeKind.Unspecified).AddTicks(7366), new TimeSpan(0, 0, 0, 0, 0)), "admin", "$2a$11$wavn.EqSjRjLzfaE9jsN6uRLgU51Uu6o39kZUOQld11HwF9En7imy", "Admin", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f3fb42f-69ba-4b24-9b26-a43b5986db4a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Email", "Password", "Role", "UpdatedById", "UpdatedOn" },
                values: new object[] { new Guid("b9b04a46-f520-4682-94fd-d510239c5920"), null, new DateTime(2021, 11, 21, 15, 0, 53, 928, DateTimeKind.Local).AddTicks(185), "admin", "", "Admin", null, null });
        }
    }
}
