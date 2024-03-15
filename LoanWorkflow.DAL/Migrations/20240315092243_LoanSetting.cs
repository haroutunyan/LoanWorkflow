using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWorkflow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LoanSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RealEstateType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "RealEstateType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "RealEstateType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "RealEstateType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "RealEstateType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "MovableEstateType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "MovableEstateType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "MovableEstateType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "MovableEstateType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "MovableEstateType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinMonthlyPrincipal",
                table: "LoanSetting",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateType_Deleted",
                table: "RealEstateType",
                column: "Deleted",
                filter: "[Deleted] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovableEstateType_Deleted",
                table: "MovableEstateType",
                column: "Deleted",
                filter: "[Deleted] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealEstateType_Deleted",
                table: "RealEstateType");

            migrationBuilder.DropIndex(
                name: "IX_MovableEstateType_Deleted",
                table: "MovableEstateType");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RealEstateType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RealEstateType");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RealEstateType");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RealEstateType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RealEstateType");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "MovableEstateType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MovableEstateType");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MovableEstateType");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "MovableEstateType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "MovableEstateType");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinMonthlyPrincipal",
                table: "LoanSetting",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
