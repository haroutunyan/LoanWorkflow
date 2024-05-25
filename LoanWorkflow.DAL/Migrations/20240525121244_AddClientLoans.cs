using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClientLoans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clients_SSN",
                table: "Clients",
                column: "SSN");

            migrationBuilder.CreateTable(
                name: "ClientLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientSSN = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    LoanProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepaymentType = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivingMethod = table.Column<int>(type: "int", nullable: false),
                    AttachedFile1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachedFile2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanTypeId1 = table.Column<short>(type: "smallint", nullable: true),
                    LoanProductTypeId1 = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientLoans_Clients_ClientSSN",
                        column: x => x.ClientSSN,
                        principalTable: "Clients",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientLoans_LoanProductType_LoanProductTypeId1",
                        column: x => x.LoanProductTypeId1,
                        principalTable: "LoanProductType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientLoans_LoanType_LoanTypeId1",
                        column: x => x.LoanTypeId1,
                        principalTable: "LoanType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_ClientSSN",
                table: "ClientLoans",
                column: "ClientSSN");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_Deleted",
                table: "ClientLoans",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanProductTypeId1",
                table: "ClientLoans",
                column: "LoanProductTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoans_LoanTypeId1",
                table: "ClientLoans",
                column: "LoanTypeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientLoans");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clients_SSN",
                table: "Clients");
        }
    }
}
