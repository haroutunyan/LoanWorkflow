using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DocType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Files",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateTable(
                name: "DocTypes",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DocTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { (short)1, "Անձնագիր", "Անձնագիր" },
                    { (short)2, "Սոցիալական քարտ", "Սոց․ քարտ" },
                    { (short)3, "Նույնականացման քարտ", "Նույնականացման քարտ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Files",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);
        }
    }
}
