using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSharp.DataAccess.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Users",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Email", "Password", "Role", "UpdatedById", "UpdatedOn" },
                values: new object[] { new Guid("b9b04a46-f520-4682-94fd-d510239c5920"), null, new DateTime(2021, 11, 21, 15, 0, 53, 928, DateTimeKind.Local).AddTicks(185), "admin", "", "Admin", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9b04a46-f520-4682-94fd-d510239c5920"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
