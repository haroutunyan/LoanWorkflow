using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EVehicle",
                columns: table => new
                {
                    VehicleDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerCertId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnginePower = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineHp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChassisNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BodyNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TemporaryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransitNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecialNotes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Released = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecordingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehicleTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehicleGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberPlateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsBlocked = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsuranceInfo_StartDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    InsuranceInfo_EndDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    InsuranceInfo_InsuranceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVehicle", x => new { x.VehicleDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_EVehicle_Vehicles_VehicleDataId",
                        column: x => x.VehicleDataId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lenders",
                columns: table => new
                {
                    EVehicleVehicleDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVehicleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalityCountryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ssn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shares = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsLegalEntity = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AllowedLending = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenders", x => new { x.EVehicleVehicleDataId, x.EVehicleId, x.Id });
                    table.ForeignKey(
                        name: "FK_Lenders_EVehicle_EVehicleVehicleDataId_EVehicleId",
                        columns: x => new { x.EVehicleVehicleDataId, x.EVehicleId },
                        principalTable: "EVehicle",
                        principalColumns: new[] { "VehicleDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwners",
                columns: table => new
                {
                    EVehicleVehicleDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVehicleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentificationNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalityCountryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Psn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsHolder = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsLegalEntity = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    Shares = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwners", x => new { x.EVehicleVehicleDataId, x.EVehicleId, x.Id });
                    table.ForeignKey(
                        name: "FK_VehicleOwners_EVehicle_EVehicleVehicleDataId_EVehicleId",
                        columns: x => new { x.EVehicleVehicleDataId, x.EVehicleId },
                        principalTable: "EVehicle",
                        principalColumns: new[] { "VehicleDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lenders");

            migrationBuilder.DropTable(
                name: "VehicleOwners");

            migrationBuilder.DropTable(
                name: "EVehicle");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
