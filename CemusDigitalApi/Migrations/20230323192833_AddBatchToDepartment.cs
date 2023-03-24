using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CemusDigitalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchToDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Batchs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_DepartmentId",
                table: "Batchs",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Departments_DepartmentId",
                table: "Batchs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Departments_DepartmentId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_DepartmentId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Batchs");
        }
    }
}
