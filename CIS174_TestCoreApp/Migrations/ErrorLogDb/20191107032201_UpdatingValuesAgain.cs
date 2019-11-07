using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations.ErrorLogDb
{
    public partial class UpdatingValuesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusCode",
                table: "ErrorLogs",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "ErrorLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
