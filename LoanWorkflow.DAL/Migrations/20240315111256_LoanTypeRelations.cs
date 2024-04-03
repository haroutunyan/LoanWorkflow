using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LoanTypeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanType_ParentId",
                table: "LoanType");

            migrationBuilder.CreateIndex(
                name: "IX_LoanType_ParentId",
                table: "LoanType",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanType_ParentId",
                table: "LoanType");

            migrationBuilder.CreateIndex(
                name: "IX_LoanType_ParentId",
                table: "LoanType",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");
        }
    }
}
