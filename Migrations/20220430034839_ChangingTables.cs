using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AccountedOfFamily.Migrations
{
    public partial class ChangingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitingTransactions_WCategories_WCategoryId",
                table: "WaitingTransactions");

            migrationBuilder.DropTable(
                name: "WCategories");

            migrationBuilder.DropIndex(
                name: "IX_WaitingTransactions_WCategoryId",
                table: "WaitingTransactions");

            migrationBuilder.DropColumn(
                name: "WCategoryId",
                table: "WaitingTransactions");

            migrationBuilder.AddColumn<bool>(
                name: "isIncome",
                table: "WaitingTransactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isIncome",
                table: "WaitingTransactions");

            migrationBuilder.AddColumn<long>(
                name: "WCategoryId",
                table: "WaitingTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "WCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitingTransactions_WCategoryId",
                table: "WaitingTransactions",
                column: "WCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingTransactions_WCategories_WCategoryId",
                table: "WaitingTransactions",
                column: "WCategoryId",
                principalTable: "WCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
