using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addnewdoctypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "Համաձայնագիր ԱՔՌԱ,ՆՈՐՔ , ԷԿԵՆԳ հարցումների համար", "Համաձայնագիր" },
                    { 5, "Դիմում-Հայտ", "Դիմում-Հայտ" },
                    { 6, "Տեղեկանք եկամտի մասին", "Տեղեկանք եկամտի մասին" },
                    { 7, "Ամուսնության վկայական", "Ամուսնության վկայական" },
                    { 8, "Միասնական տեղեկանք", "Միասնական տեղեկանք" },
                    { 9, "Գրավի վկայական", "Գրավի վկայական" },
                    { 10, "Այլ", "Այլ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
