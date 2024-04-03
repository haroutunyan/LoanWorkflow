using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addindoctypesentytyproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "DocTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "DocTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "DocTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "DocTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "DocTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.UpdateData(
                table: "DocTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "CreatedBy", "Deleted", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L });

            migrationBuilder.CreateIndex(
                name: "IX_DocTypes_Deleted",
                table: "DocTypes",
                column: "Deleted",
                filter: "[Deleted] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DocTypes_Deleted",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "DocTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "DocTypes");
        }
    }
}
