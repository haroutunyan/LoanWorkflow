using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedECivil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "PersonalInfoBase",
                newName: "PersonalInfoType");

            migrationBuilder.CreateTable(
                name: "CivilPersons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ssn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentDepartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastNameBeforeMarriage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarriageNumber = table.Column<int>(type: "int", nullable: true),
                    Birth_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birth_Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birth_Community = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_FathersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_BirthDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    BaseInfo_Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ECivil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullRefNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackingId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PresenterId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    Person2Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECivil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ECivil_CivilPersons_Person2Id",
                        column: x => x.Person2Id,
                        principalTable: "CivilPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ECivil_CivilPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "CivilPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ECivil_CivilPersons_PresenterId",
                        column: x => x.PresenterId,
                        principalTable: "CivilPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ECivil_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ECivilResident",
                columns: table => new
                {
                    CivilPersonId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Community = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HouseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    House = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECivilResident", x => x.CivilPersonId);
                    table.ForeignKey(
                        name: "FK_ECivilResident_CivilPersons_CivilPersonId",
                        column: x => x.CivilPersonId,
                        principalTable: "CivilPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ECivilChild",
                columns: table => new
                {
                    ECivilDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_FathersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseInfo_BirthDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    BaseInfo_Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BornChildrenCount = table.Column<int>(type: "int", nullable: true),
                    ChildNumber = table.Column<int>(type: "int", nullable: true),
                    BirthStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birth_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birth_Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birth_Community = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECivilChild", x => x.ECivilDataId);
                    table.ForeignKey(
                        name: "FK_ECivilChild_ECivil_ECivilDataId",
                        column: x => x.ECivilDataId,
                        principalTable: "ECivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ECivilDeath",
                columns: table => new
                {
                    ECivilDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Age = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unidentified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECivilDeath", x => x.ECivilDataId);
                    table.ForeignKey(
                        name: "FK_ECivilDeath_ECivil_ECivilDataId",
                        column: x => x.ECivilDataId,
                        principalTable: "ECivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CivilPersons_Deleted",
                table: "CivilPersons",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ECivil_Person2Id",
                table: "ECivil",
                column: "Person2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ECivil_PersonId",
                table: "ECivil",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ECivil_PresenterId",
                table: "ECivil",
                column: "PresenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECivilChild");

            migrationBuilder.DropTable(
                name: "ECivilDeath");

            migrationBuilder.DropTable(
                name: "ECivilResident");

            migrationBuilder.DropTable(
                name: "ECivil");

            migrationBuilder.DropTable(
                name: "CivilPersons");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoType",
                table: "PersonalInfoBase",
                newName: "Type");
        }
    }
}
