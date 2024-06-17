using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTwoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<int>(type: "int", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<int>(type: "int", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncome_ActivityPositionId",
                table: "OtherIncome",
                column: "ActivityPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncome_ActivityTypeId",
                table: "OtherIncome",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_Activity_ActivityTypeId",
                table: "OtherIncome",
                column: "ActivityTypeId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherIncome_Position_ActivityPositionId",
                table: "OtherIncome",
                column: "ActivityPositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_Activity_ActivityTypeId",
                table: "OtherIncome");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherIncome_Position_ActivityPositionId",
                table: "OtherIncome");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_OtherIncome_ActivityPositionId",
                table: "OtherIncome");

            migrationBuilder.DropIndex(
                name: "IX_OtherIncome_ActivityTypeId",
                table: "OtherIncome");
        }
    }
}
