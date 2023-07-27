using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseManagement.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpenseCategoryName",
                table: "ExpencesCategory",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryId",
                table: "Expences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expences_ExpenseCategoryId",
                table: "Expences",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpencesCategory_ExpenseCategoryId",
                table: "Expences",
                column: "ExpenseCategoryId",
                principalTable: "ExpencesCategory",
                principalColumn: "ExpenseCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpencesCategory_ExpenseCategoryId",
                table: "Expences");

            migrationBuilder.DropIndex(
                name: "IX_Expences_ExpenseCategoryId",
                table: "Expences");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "Expences");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseCategoryName",
                table: "ExpencesCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }
    }
}
