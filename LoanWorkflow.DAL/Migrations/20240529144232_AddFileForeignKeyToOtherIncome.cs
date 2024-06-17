using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFileForeignKeyToOtherIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicantFiles_FileId",
                table: "ApplicantFiles");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ApplicantFiles_FileId",
                table: "ApplicantFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncome_FileId",
                table: "OtherIncome",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_FileId",
                table: "OtherIncome",
                column: "FileId",
                principalTable: "ApplicantFiles",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_FileId",
                table: "OtherIncome");

            migrationBuilder.DropIndex(
                name: "IX_OtherIncome_FileId",
                table: "OtherIncome");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ApplicantFiles_FileId",
                table: "ApplicantFiles");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_FileId",
                table: "ApplicantFiles",
                column: "FileId");
        }
    }
}
