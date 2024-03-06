using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocType",
                table: "Files",
                newName: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DocTypeId",
                table: "Files",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_DocTypes_DocTypeId",
                table: "Files",
                column: "DocTypeId",
                principalTable: "DocTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_DocTypes_DocTypeId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DocTypeId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "DocTypeId",
                table: "Files",
                newName: "DocType");
        }
    }
}
