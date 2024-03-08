using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedPersonalInfosAndRelatedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DocIssuer = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActualAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SecondPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfoBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfoBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Sphere = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    GrossIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicServiceNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SsnIndicator = table.Column<bool>(type: "bit", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvvData_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantFiles_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPersonalInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantPersonalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantPersonalInfos_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantPersonalInfos_PersonalInfoBase_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvvAddresses",
                columns: table => new
                {
                    AvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvAddresses", x => new { x.AvvDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_AvvAddresses_AvvData_AvvDataId",
                        column: x => x.AvvDataId,
                        principalTable: "AvvData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvDocuments",
                columns: table => new
                {
                    AvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OtherDocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentDepartment = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PassportData_Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PassportData_IssuanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportData_ValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportData_ForeignValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportData_ExtensionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportData_ExtensionDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PassportData_RelatedDocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PassportData_RelatedDocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportData_RelatedDocumentDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvDocuments", x => new { x.AvvDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_AvvDocuments_AvvData_AvvDataId",
                        column: x => x.AvvDataId,
                        principalTable: "AvvData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvRegistrationAddresses",
                columns: table => new
                {
                    AvvAddressAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvAddressId = table.Column<int>(type: "int", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PostalIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Community = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Building = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BuildingType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvRegistrationAddresses", x => new { x.AvvAddressAvvDataId, x.AvvAddressId });
                    table.ForeignKey(
                        name: "FK_AvvRegistrationAddresses_AvvAddresses_AvvAddressAvvDataId_AvvAddressId",
                        columns: x => new { x.AvvAddressAvvDataId, x.AvvAddressId },
                        principalTable: "AvvAddresses",
                        principalColumns: new[] { "AvvDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvRegistrationData",
                columns: table => new
                {
                    AvvAddressAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvAddressId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDepartment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TemporaryRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisteredDepartment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvRegistrationData", x => new { x.AvvAddressAvvDataId, x.AvvAddressId });
                    table.ForeignKey(
                        name: "FK_AvvRegistrationData_AvvAddresses_AvvAddressAvvDataId_AvvAddressId",
                        columns: x => new { x.AvvAddressAvvDataId, x.AvvAddressId },
                        principalTable: "AvvAddresses",
                        principalColumns: new[] { "AvvDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvResidenceDocuments",
                columns: table => new
                {
                    AvvAddressAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvAddressId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResidenceDocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentValidityDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvResidenceDocuments", x => new { x.AvvAddressAvvDataId, x.AvvAddressId });
                    table.ForeignKey(
                        name: "FK_AvvResidenceDocuments_AvvAddresses_AvvAddressAvvDataId_AvvAddressId",
                        columns: x => new { x.AvvAddressAvvDataId, x.AvvAddressId },
                        principalTable: "AvvAddresses",
                        principalColumns: new[] { "AvvDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvBasicDocuments",
                columns: table => new
                {
                    AvvDocumentAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvDocumentId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CountryShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvBasicDocuments", x => new { x.AvvDocumentAvvDataId, x.AvvDocumentId });
                    table.ForeignKey(
                        name: "FK_AvvBasicDocuments_AvvDocuments_AvvDocumentAvvDataId_AvvDocumentId",
                        columns: x => new { x.AvvDocumentAvvDataId, x.AvvDocumentId },
                        principalTable: "AvvDocuments",
                        principalColumns: new[] { "AvvDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvPersons",
                columns: table => new
                {
                    AvvDocumentAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvDocumentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PatronymicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genus = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    EnglishLastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EnglishFirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EnglishPatronymicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthCommunity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthResidence = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthCountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthCountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    BirthCountryShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    NationalityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NationalityCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvPersons", x => new { x.AvvDocumentAvvDataId, x.AvvDocumentId });
                    table.ForeignKey(
                        name: "FK_AvvPersons_AvvDocuments_AvvDocumentAvvDataId_AvvDocumentId",
                        columns: x => new { x.AvvDocumentAvvDataId, x.AvvDocumentId },
                        principalTable: "AvvDocuments",
                        principalColumns: new[] { "AvvDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvvCitizenships",
                columns: table => new
                {
                    AvvPersonAvvDocumentAvvDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvvPersonAvvDocumentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CitizenshipStoppedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CountryShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvCitizenships", x => new { x.AvvPersonAvvDocumentAvvDataId, x.AvvPersonAvvDocumentId, x.Id });
                    table.ForeignKey(
                        name: "FK_AvvCitizenships_AvvPersons_AvvPersonAvvDocumentAvvDataId_AvvPersonAvvDocumentId",
                        columns: x => new { x.AvvPersonAvvDocumentAvvDataId, x.AvvPersonAvvDocumentId },
                        principalTable: "AvvPersons",
                        principalColumns: new[] { "AvvDocumentAvvDataId", "AvvDocumentId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_ApplicantId",
                table: "ApplicantFiles",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_Deleted",
                table: "ApplicantFiles",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_FileId",
                table: "ApplicantFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPersonalInfos_ApplicantId",
                table: "ApplicantPersonalInfos",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPersonalInfos_Deleted",
                table: "ApplicantPersonalInfos",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPersonalInfos_PersonalInfoId",
                table: "ApplicantPersonalInfos",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_ClientId",
                table: "Applicants",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_Deleted",
                table: "Applicants",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Deleted",
                table: "Clients",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ClientId",
                table: "Incomes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_Deleted",
                table: "Incomes",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfoBase_Deleted",
                table: "PersonalInfoBase",
                column: "Deleted",
                filter: "[Deleted] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantFiles");

            migrationBuilder.DropTable(
                name: "ApplicantPersonalInfos");

            migrationBuilder.DropTable(
                name: "AvvBasicDocuments");

            migrationBuilder.DropTable(
                name: "AvvCitizenships");

            migrationBuilder.DropTable(
                name: "AvvRegistrationAddresses");

            migrationBuilder.DropTable(
                name: "AvvRegistrationData");

            migrationBuilder.DropTable(
                name: "AvvResidenceDocuments");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "AvvPersons");

            migrationBuilder.DropTable(
                name: "AvvAddresses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AvvDocuments");

            migrationBuilder.DropTable(
                name: "AvvData");

            migrationBuilder.DropTable(
                name: "PersonalInfoBase");
        }
    }
}
