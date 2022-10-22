using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountedOfFamily.Migrations
{
    public partial class ChangeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "DateSart",
                table: "Deposits",
                newName: "DateStart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Deposits",
                newName: "DateSart");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Expenses",
                type: "text",
                nullable: true);
        }
    }
}
