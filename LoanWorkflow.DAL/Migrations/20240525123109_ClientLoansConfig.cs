using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ClientLoansConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLoans_LoanProductType_LoanProductTypeId1",
                table: "ClientLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientLoans_LoanType_LoanTypeId1",
                table: "ClientLoans");

            migrationBuilder.DropIndex(
                name: "IX_ClientLoans_LoanProductTypeId1",
                table: "ClientLoans");

            migrationBuilder.DropIndex(
                name: "IX_ClientLoans_LoanTypeId1",
                table: "ClientLoans");

            migrationBuilder.DropColumn(
                name: "LoanProductTypeId1",
                table: "ClientLoans");

            migrationBuilder.DropColumn(
                name: "LoanTypeId1",
                table: "ClientLoans");

            migrationBuilder.AlterColumn<short>(
                name: "LoanTypeId",
                table: "ClientLoans",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "LoanProductTypeId",
                table: "ClientLoans",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "LoanId",
                table: "ClientLoans",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "ClientLoans",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "ClientLoans",
                type: "nvarchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanProductTypeId",
                table: "ClientLoans",
                column: "LoanProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanTypeId",
                table: "ClientLoans",
                column: "LoanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLoans_LoanProductType_LoanProductTypeId",
                table: "ClientLoans",
                column: "LoanProductTypeId",
                principalTable: "LoanProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLoans_LoanType_LoanTypeId",
                table: "ClientLoans",
                column: "LoanTypeId",
                principalTable: "LoanType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLoans_LoanProductType_LoanProductTypeId",
                table: "ClientLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientLoans_LoanType_LoanTypeId",
                table: "ClientLoans");

            migrationBuilder.DropIndex(
                name: "IX_ClientLoans_LoanProductTypeId",
                table: "ClientLoans");

            migrationBuilder.DropIndex(
                name: "IX_ClientLoans_LoanTypeId",
                table: "ClientLoans");

            migrationBuilder.AlterColumn<int>(
                name: "LoanTypeId",
                table: "ClientLoans",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "LoanProductTypeId",
                table: "ClientLoans",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "LoanId",
                table: "ClientLoans",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "ClientLoans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "ClientLoans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AddColumn<short>(
                name: "LoanProductTypeId1",
                table: "ClientLoans",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "LoanTypeId1",
                table: "ClientLoans",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanProductTypeId1",
                table: "ClientLoans",
                column: "LoanProductTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanTypeId1",
                table: "ClientLoans",
                column: "LoanTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLoans_LoanProductType_LoanProductTypeId1",
                table: "ClientLoans",
                column: "LoanProductTypeId1",
                principalTable: "LoanProductType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLoans_LoanType_LoanTypeId1",
                table: "ClientLoans",
                column: "LoanTypeId1",
                principalTable: "LoanType",
                principalColumn: "Id");
        }
    }
}
