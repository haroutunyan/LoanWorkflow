using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedCesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CesData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CesData_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inquests",
                columns: table => new
                {
                    CesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InquestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aliment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlaintiffName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InquestState = table.Column<int>(type: "int", nullable: true),
                    InquestType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DistributionProcedure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Article = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourtId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldOrderText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemainingSum = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: true),
                    RecoverSum = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: true),
                    CalcPersent = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquests", x => new { x.CesDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_Inquests_CesData_CesDataId",
                        column: x => x.CesDataId,
                        principalTable: "CesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquests");

            migrationBuilder.DropTable(
                name: "CesData");
        }
    }
}
