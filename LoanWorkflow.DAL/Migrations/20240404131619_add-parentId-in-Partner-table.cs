using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addparentIdinPartnertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Partner",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partner_ParentId",
                table: "Partner",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partner_Partner_ParentId",
                table: "Partner",
                column: "ParentId",
                principalTable: "Partner",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partner_Partner_ParentId",
                table: "Partner");

            migrationBuilder.DropIndex(
                name: "IX_Partner_ParentId",
                table: "Partner");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Partner");
        }
    }
}
