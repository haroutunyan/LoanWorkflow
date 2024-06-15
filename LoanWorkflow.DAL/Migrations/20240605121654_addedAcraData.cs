using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedAcraData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcraData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReqID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Error = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ErrorDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcraData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcraData_PersonalInfoBase_Id",
                        column: x => x.Id,
                        principalTable: "PersonalInfoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AggregateType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventData = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participients",
                columns: table => new
                {
                    AcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThePresenceData = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KindBorrower = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActivityScope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequestTarget = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsageRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateofBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SocCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonBankruptIncome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SelfInquiryQuantity30 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SelfInquiryQuantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequestQuantity30 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequestQuantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ErrorDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcraId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participients", x => x.AcraDataId);
                    table.ForeignKey(
                        name: "FK_Participients_AcraData_AcraDataId",
                        column: x => x.AcraDataId,
                        principalTable: "AcraData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcraGuarantees",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActualCreditStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuaranteeCancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastInstallment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnnualRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountDue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GuaranteeLastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TheGuaranteeClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditScope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditUsePlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncomingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountOverdue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingPercent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassificationLastDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProlongationsNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GuarantorAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditNotes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverdueDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GuarantorOverdueDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PledgeSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralNotes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralCurrency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcraGuarantees", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_AcraGuarantees_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcraLoans",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActualCreditStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncomingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastInstallment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnnualRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountDue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountOverdue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingPercent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoanLastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TheLoanClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditScope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditUsePlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverdueDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassificationLastDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditNotes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProlongationsNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PledgeSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralNotes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollateralCurrency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PossiblePayments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcraLoans", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_AcraLoans_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcraRequests",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcraRequests", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_AcraRequests_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountOfGuarantees",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Current = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Closed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountOfGuarantees", x => x.ParticipientAcraDataId);
                    table.ForeignKey(
                        name: "FK_CountOfGuarantees_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountOfLoans",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Current = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Closed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountOfLoans", x => x.ParticipientAcraDataId);
                    table.ForeignKey(
                        name: "FK_CountOfLoans_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interrelated",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtorNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interrelated", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_Interrelated_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalLiabilitiesGuarantees",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalLiabilitiesGuarantees", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_TotalLiabilitiesGuarantees_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalLiabilitiesLoans",
                columns: table => new
                {
                    ParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalLiabilitiesLoans", x => new { x.ParticipientAcraDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_TotalLiabilitiesLoans_Participients_ParticipientAcraDataId",
                        column: x => x.ParticipientAcraDataId,
                        principalTable: "Participients",
                        principalColumn: "AcraDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuaranteeOutstandingDaysCount",
                columns: table => new
                {
                    GuaranteeParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuaranteeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuaranteeOutstandingDaysCount", x => new { x.GuaranteeParticipientAcraDataId, x.GuaranteeId, x.Id });
                    table.ForeignKey(
                        name: "FK_GuaranteeOutstandingDaysCount_AcraGuarantees_GuaranteeParticipientAcraDataId_GuaranteeId",
                        columns: x => new { x.GuaranteeParticipientAcraDataId, x.GuaranteeId },
                        principalTable: "AcraGuarantees",
                        principalColumns: new[] { "ParticipientAcraDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanOutstandingDaysCount",
                columns: table => new
                {
                    LoansParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoansId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOutstandingDaysCount", x => new { x.LoansParticipientAcraDataId, x.LoansId, x.Id });
                    table.ForeignKey(
                        name: "FK_LoanOutstandingDaysCount_AcraLoans_LoansParticipientAcraDataId_LoansId",
                        columns: x => new { x.LoansParticipientAcraDataId, x.LoansId },
                        principalTable: "AcraLoans",
                        principalColumns: new[] { "ParticipientAcraDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterrelatedLoans",
                columns: table => new
                {
                    InterrelatedParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterrelatedId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastInstallment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountDue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountOverdue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingPercent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutstandingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditClassification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InterrelatedSourceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterrelatedLoans", x => new { x.InterrelatedParticipientAcraDataId, x.InterrelatedId, x.Id });
                    table.ForeignKey(
                        name: "FK_InterrelatedLoans_Interrelated_InterrelatedParticipientAcraDataId_InterrelatedId",
                        columns: x => new { x.InterrelatedParticipientAcraDataId, x.InterrelatedId },
                        principalTable: "Interrelated",
                        principalColumns: new[] { "ParticipientAcraDataId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuaranteeOutstandingDaysCount_Months",
                columns: table => new
                {
                    YearGuaranteeParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearGuaranteeId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuaranteeOutstandingDaysCount_Months", x => new { x.YearGuaranteeParticipientAcraDataId, x.YearGuaranteeId, x.YearId, x.Id });
                    table.ForeignKey(
                        name: "FK_GuaranteeOutstandingDaysCount_Months_GuaranteeOutstandingDaysCount_YearGuaranteeParticipientAcraDataId_YearGuaranteeId_YearId",
                        columns: x => new { x.YearGuaranteeParticipientAcraDataId, x.YearGuaranteeId, x.YearId },
                        principalTable: "GuaranteeOutstandingDaysCount",
                        principalColumns: new[] { "GuaranteeParticipientAcraDataId", "GuaranteeId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanOutstandingDaysCount_Months",
                columns: table => new
                {
                    YearLoansParticipientAcraDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearLoansId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOutstandingDaysCount_Months", x => new { x.YearLoansParticipientAcraDataId, x.YearLoansId, x.YearId, x.Id });
                    table.ForeignKey(
                        name: "FK_LoanOutstandingDaysCount_Months_LoanOutstandingDaysCount_YearLoansParticipientAcraDataId_YearLoansId_YearId",
                        columns: x => new { x.YearLoansParticipientAcraDataId, x.YearLoansId, x.YearId },
                        principalTable: "LoanOutstandingDaysCount",
                        principalColumns: new[] { "LoansParticipientAcraDataId", "LoansId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Deleted",
                table: "Events",
                column: "Deleted",
                filter: "[Deleted] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcraRequests");

            migrationBuilder.DropTable(
                name: "CountOfGuarantees");

            migrationBuilder.DropTable(
                name: "CountOfLoans");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GuaranteeOutstandingDaysCount_Months");

            migrationBuilder.DropTable(
                name: "InterrelatedLoans");

            migrationBuilder.DropTable(
                name: "LoanOutstandingDaysCount_Months");

            migrationBuilder.DropTable(
                name: "TotalLiabilitiesGuarantees");

            migrationBuilder.DropTable(
                name: "TotalLiabilitiesLoans");

            migrationBuilder.DropTable(
                name: "GuaranteeOutstandingDaysCount");

            migrationBuilder.DropTable(
                name: "Interrelated");

            migrationBuilder.DropTable(
                name: "LoanOutstandingDaysCount");

            migrationBuilder.DropTable(
                name: "AcraGuarantees");

            migrationBuilder.DropTable(
                name: "AcraLoans");

            migrationBuilder.DropTable(
                name: "Participients");

            migrationBuilder.DropTable(
                name: "AcraData");
        }
    }
}
