using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FileType1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocType = table.Column<short>(type: "smallint", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_Deleted",
                table: "Files",
                column: "Deleted",
                filter: "[Deleted] IS NULL");
        }
    }
}
