using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class birthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Therapists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Therapists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Sanitaries",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Sanitaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Nurses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Equipments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Doctors",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Diagnostics",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Diagnostics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Therapists");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Therapists");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Sanitaries");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Sanitaries");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Diagnostics");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Diagnostics");
        }
    }
}
