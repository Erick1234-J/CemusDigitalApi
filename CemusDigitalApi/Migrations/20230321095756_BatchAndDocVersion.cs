using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CemusDigitalApi.Migrations
{
    /// <inheritdoc />
    public partial class BatchAndDocVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Version_VersionId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Version");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                table: "Batch");

            migrationBuilder.RenameTable(
                name: "Batch",
                newName: "Batchs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batchs",
                table: "Batchs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versions_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Versions_BatchId",
                table: "Versions",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Versions_VersionId",
                table: "Documents",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Versions_VersionId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batchs",
                table: "Batchs");

            migrationBuilder.RenameTable(
                name: "Batchs",
                newName: "Batch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                table: "Batch",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Version",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Version_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Version_BatchId",
                table: "Version",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Version_VersionId",
                table: "Documents",
                column: "VersionId",
                principalTable: "Version",
                principalColumn: "Id");
        }
    }
}
