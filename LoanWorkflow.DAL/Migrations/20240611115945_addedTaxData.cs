using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedTaxData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxData_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayerInfos",
                columns: table => new
                {
                    TaxDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxPayerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayerInfos", x => new { x.TaxDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_TaxPayerInfos_TaxData_TaxDataId",
                        column: x => x.TaxDataId,
                        principalTable: "TaxData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInfoPeriods",
                columns: table => new
                {
                    TaxPayerInfoTaxDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxPayerInfoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfoPeriods", x => new { x.TaxPayerInfoTaxDataId, x.TaxPayerInfoId, x.Id });
                    table.ForeignKey(
                        name: "FK_PersonInfoPeriods_TaxPayerInfos_TaxPayerInfoTaxDataId_TaxPayerInfoId",
                        columns: x => new { x.TaxPayerInfoTaxDataId, x.TaxPayerInfoId },
                        principalTable: "TaxPayerInfos",
                        principalColumns: new[] { "TaxDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInfo",
                columns: table => new
                {
                    PersonInfoPeriodTaxPayerInfoTaxDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonInfoPeriodTaxPayerInfoId = table.Column<int>(type: "int", nullable: false),
                    PersonInfoPeriodId = table.Column<int>(type: "int", nullable: false),
                    IncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Socialpayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialPaymentsPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    SalaryEquivPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CivilLowContractPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfo", x => new { x.PersonInfoPeriodTaxPayerInfoTaxDataId, x.PersonInfoPeriodTaxPayerInfoId, x.PersonInfoPeriodId });
                    table.ForeignKey(
                        name: "FK_PersonInfo_PersonInfoPeriods_PersonInfoPeriodTaxPayerInfoTaxDataId_PersonInfoPeriodTaxPayerInfoId_PersonInfoPeriodId",
                        columns: x => new { x.PersonInfoPeriodTaxPayerInfoTaxDataId, x.PersonInfoPeriodTaxPayerInfoId, x.PersonInfoPeriodId },
                        principalTable: "PersonInfoPeriods",
                        principalColumns: new[] { "TaxPayerInfoTaxDataId", "TaxPayerInfoId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInfo");

            migrationBuilder.DropTable(
                name: "PersonInfoPeriods");

            migrationBuilder.DropTable(
                name: "TaxPayerInfos");

            migrationBuilder.DropTable(
                name: "TaxData");
        }
    }
}
