using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOtherIncomeFileType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_FileId",
                table: "OtherIncome");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ApplicantFiles_FileId",
                table: "ApplicantFiles");

            migrationBuilder.AddColumn<long>(
                name: "ApplicantFileId",
                table: "OtherIncome",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncome_ApplicantFileId",
                table: "OtherIncome",
                column: "ApplicantFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_FileId",
                table: "ApplicantFiles",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_ApplicantFileId",
                table: "OtherIncome",
                column: "ApplicantFileId",
                principalTable: "ApplicantFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_Files_FileId",
                table: "OtherIncome",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_ApplicantFileId",
                table: "OtherIncome");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_Files_FileId",
                table: "OtherIncome");

            migrationBuilder.DropIndex(
                name: "IX_OtherIncome_ApplicantFileId",
                table: "OtherIncome");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantFiles_FileId",
                table: "ApplicantFiles");

            migrationBuilder.DropColumn(
                name: "ApplicantFileId",
                table: "OtherIncome");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ApplicantFiles_FileId",
                table: "ApplicantFiles",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_ApplicantFiles_FileId",
                table: "OtherIncome",
                column: "FileId",
                principalTable: "ApplicantFiles",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
