using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FileType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Files",
                newName: "DocType");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Files",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "DocType",
                table: "Files",
                newName: "Type");
        }
    }
}
