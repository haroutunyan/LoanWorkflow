using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addrelationloantypefile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PartnerId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "LoanType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PartnerId",
                table: "User",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanType_FileId",
                table: "LoanType",
                column: "FileId",
                unique: true,
                filter: "[FileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_Deleted",
                table: "Partner",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanType_Files_FileId",
                table: "LoanType",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Partner_PartnerId",
                table: "User",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanType_Files_FileId",
                table: "LoanType");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Partner_PartnerId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropIndex(
                name: "IX_User_PartnerId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_LoanType_FileId",
                table: "LoanType");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "LoanType");
        }
    }
}
