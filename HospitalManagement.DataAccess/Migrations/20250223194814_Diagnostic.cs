using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Diagnostic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostics_Departments_DepartmentId",
                table: "Diagnostics");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Equipments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "You can use 20 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Equipments",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                comment: "Max 9 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Equipments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Equipments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "You can use 20 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "Equipments",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                comment: "Max 8 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Equipments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Equipments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Max 50 symbols can use",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Diagnostics",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "You can use 20 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Diagnostics",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                comment: "Max 9 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Diagnostics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnostics",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "You can use 20 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "Diagnostics",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                comment: "Max 8 symbol",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Diagnostics",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Diagnostics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Diagnostics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Diagnostics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Max 50 symbols can use",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Id",
                table: "Equipments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_Id",
                table: "Diagnostics",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostics_Departments_DepartmentId",
                table: "Diagnostics",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostics_Departments_DepartmentId",
                table: "Diagnostics");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Id",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostics_Id",
                table: "Diagnostics");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "You can use 20 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true,
                oldComment: "Max 9 symbol");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Equipments",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "You can use 20 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true,
                oldComment: "Max 8 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Equipments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Equipments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Max 50 symbols can use");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "You can use 20 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true,
                oldComment: "Max 9 symbol");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Diagnostics",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "You can use 20 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true,
                oldComment: "Max 8 symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Diagnostics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Diagnostics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Diagnostics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Max 50 symbols can use");

            migrationBuilder.CreateTable(
                name: "BlackListedTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackListedTokens", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostics_Departments_DepartmentId",
                table: "Diagnostics",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
