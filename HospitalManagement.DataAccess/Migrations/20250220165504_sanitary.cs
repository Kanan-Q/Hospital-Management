using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sanitary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sanitaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FIN = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "Max 8 symbol"),
                    Series = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true, comment: "Max 9 symbol"),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanitaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanitaries_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sanitaries_DepartmentId",
                table: "Sanitaries",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanitaries_Id",
                table: "Sanitaries",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sanitaries");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Nurses");
        }
    }
}
