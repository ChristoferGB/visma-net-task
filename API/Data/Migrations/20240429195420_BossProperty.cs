using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class BossProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BossId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BossId",
                table: "Employees",
                column: "BossId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_BossId",
                table: "Employees",
                column: "BossId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_BossId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BossId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BossId",
                table: "Employees");
        }
    }
}
