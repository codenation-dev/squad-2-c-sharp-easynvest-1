using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class norequertoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TOKEN",
                table: "USERS",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TOKEN",
                table: "USERS",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
