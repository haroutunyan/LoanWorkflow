using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "DocTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateRangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDateRange = table.Column<short>(type: "smallint", nullable: false),
                    MaxDateRange = table.Column<short>(type: "smallint", nullable: false),
                    MinSum = table.Column<int>(type: "int", nullable: false),
                    MaxSum = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<short>(type: "smallint", nullable: false),
                    MaxAge = table.Column<short>(type: "smallint", nullable: false),
                    MinActualRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxActualRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SumIncrementStep = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthIncrementStep = table.Column<int>(type: "int", nullable: false),
                    MinMonthlyPrincipal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionChargeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepaymentChargeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvisionFeePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrincipalPenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentPenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanProvidingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasPledge = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanType_LoanType_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LoanType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovableEstateType",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovableEstateType", x => x.Type);
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
                name: "RealEstateType",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateType", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_Applicants_Applicants_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
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
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Data = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DocTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_DocTypes_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApproverGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    MaxApprovableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApproveCountPerRole = table.Column<byte>(type: "tinyint", nullable: false),
                    ApproveCountByPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproverGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApproverGroup_LoanType_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanProductType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TermsId = table.Column<int>(type: "int", nullable: false),
                    AgrrementId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProductType_LoanType_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanType",
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
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPersonalInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "PledgeBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContractDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnifiedInfoNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UnifiedInfoIssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AppraisalCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppraisalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ApplicantId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    MovableEstateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CarCertificateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MakeYear = table.Column<int>(type: "int", nullable: true),
                    MovableEstateTypeType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RealEstateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Square = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OwnershipNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OwnershipIssueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AppraisalActNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AppraisedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    LiquidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PledgeCertificateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RealEstateTypeType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PledgeBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PledgeBase_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PledgeBase_MovableEstateType_MovableEstateTypeType",
                        column: x => x.MovableEstateTypeType,
                        principalTable: "MovableEstateType",
                        principalColumn: "Type");
                    table.ForeignKey(
                        name: "FK_PledgeBase_RealEstateType_RealEstateTypeType",
                        column: x => x.RealEstateTypeType,
                        principalTable: "RealEstateType",
                        principalColumn: "Type");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "RoleApprover",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverGroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleApprover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleApprover_ApproverGroup_ApproverGroupId",
                        column: x => x.ApproverGroupId,
                        principalTable: "ApproverGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleApprover_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleApprover_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanProductSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsLoanCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<short>(type: "smallint", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProductSetting_LoanProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "LoanProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanProductSetting_LoanSetting_SettingId",
                        column: x => x.SettingId,
                        principalTable: "LoanSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanProductSetting_LoanType_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanType",
                        principalColumn: "Id");
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
                name: "PledgeFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PledgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PledgeFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PledgeFile_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PledgeFile_PledgeBase_PledgId",
                        column: x => x.PledgId,
                        principalTable: "PledgeBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    RequestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequestDateRange = table.Column<short>(type: "smallint", nullable: true),
                    ActualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualDateRange = table.Column<short>(type: "smallint", nullable: true),
                    ContractEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AdvancePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovedPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedDateRange = table.Column<short>(type: "smallint", nullable: true),
                    DateRangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPAttemptCount = table.Column<byte>(type: "tinyint", nullable: false),
                    PercentConfirmationCount = table.Column<byte>(type: "tinyint", nullable: false),
                    CommunicationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotified = table.Column<bool>(type: "bit", nullable: false),
                    PreferredDay = table.Column<byte>(type: "tinyint", nullable: true),
                    LoanProductSettingId = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_LoanProductSetting_LoanProductSettingId",
                        column: x => x.LoanProductSettingId,
                        principalTable: "LoanProductSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ApproverActivity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApproverGroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproverActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApproverActivity_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApproverActivity_ApproverGroup_ApproverGroupId",
                        column: x => x.ApproverGroupId,
                        principalTable: "ApproverGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApproverActivity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "DocTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Նույնականացման քարտ", "Նույնականացման քարտ" },
                    { 2, "Անձնագիր", "Անձնագիր" },
                    { 3, "Սոցիալական քարտ", "Սոց․ քարտ" }
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
                name: "IX_Applicants_ParentId",
                table: "Applicants",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicantId",
                table: "Application",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_Deleted",
                table: "Application",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Application_LoanProductSettingId",
                table: "Application",
                column: "LoanProductSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverActivity_ApplicationId",
                table: "ApproverActivity",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverActivity_ApproverGroupId",
                table: "ApproverActivity",
                column: "ApproverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverActivity_Deleted",
                table: "ApproverActivity",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverActivity_UserId",
                table: "ApproverActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverGroup_Deleted",
                table: "ApproverGroup",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverGroup_LoanTypeId",
                table: "ApproverGroup",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Deleted",
                table: "Clients",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Deleted",
                table: "Files",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DocTypeId",
                table: "Files",
                column: "DocTypeId");

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
                name: "IX_LoanProductSetting_Deleted",
                table: "LoanProductSetting",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductSetting_LoanTypeId",
                table: "LoanProductSetting",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductSetting_ProductTypeId",
                table: "LoanProductSetting",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductSetting_SettingId",
                table: "LoanProductSetting",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductType_Deleted",
                table: "LoanProductType",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductType_LoanTypeId",
                table: "LoanProductType",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanSetting_Deleted",
                table: "LoanSetting",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanType_Deleted",
                table: "LoanType",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanType_ParentId",
                table: "LoanType",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfoBase_Deleted",
                table: "PersonalInfoBase",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeBase_ApplicantId",
                table: "PledgeBase",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeBase_Deleted",
                table: "PledgeBase",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeBase_MovableEstateTypeType",
                table: "PledgeBase",
                column: "MovableEstateTypeType");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeBase_RealEstateTypeType",
                table: "PledgeBase",
                column: "RealEstateTypeType");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeFile_Deleted",
                table: "PledgeFile",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeFile_FileId",
                table: "PledgeFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PledgeFile_PledgId",
                table: "PledgeFile",
                column: "PledgId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Deleted",
                table: "Role",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApprover_ApproverGroupId",
                table: "RoleApprover",
                column: "ApproverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApprover_Deleted",
                table: "RoleApprover",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApprover_RoleId",
                table: "RoleApprover",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleApprover_UserId",
                table: "RoleApprover",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_Deleted",
                table: "RoleClaim",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_Deleted",
                table: "User",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_Deleted",
                table: "UserClaim",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_Deleted",
                table: "UserLogin",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_Deleted",
                table: "UserRole",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_Deleted",
                table: "UserToken",
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
                name: "ApproverActivity");

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
                name: "PledgeFile");

            migrationBuilder.DropTable(
                name: "RoleApprover");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "AvvPersons");

            migrationBuilder.DropTable(
                name: "AvvAddresses");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "PledgeBase");

            migrationBuilder.DropTable(
                name: "ApproverGroup");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LoanProductSetting");

            migrationBuilder.DropTable(
                name: "AvvDocuments");

            migrationBuilder.DropTable(
                name: "DocTypes");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "MovableEstateType");

            migrationBuilder.DropTable(
                name: "RealEstateType");

            migrationBuilder.DropTable(
                name: "LoanProductType");

            migrationBuilder.DropTable(
                name: "LoanSetting");

            migrationBuilder.DropTable(
                name: "AvvData");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "LoanType");

            migrationBuilder.DropTable(
                name: "PersonalInfoBase");
        }
    }
}
