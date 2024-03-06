using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Files",
                newName: "Extension");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "Files",
                newName: "FileType");
        }
    }
}
