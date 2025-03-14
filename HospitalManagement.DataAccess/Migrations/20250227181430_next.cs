using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Expenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BuyDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "You can use 20 symbol"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FIN = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "Max 8 symbol"),
                    Series = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true, comment: "Max 9 symbol"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    BirthDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostics",
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
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostics_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
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
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Therapists",
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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Max 50 symbols can use"),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapists_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatients",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatients", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShedcules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShedcules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShedcules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkShedcules_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Id",
                table: "Departments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_DepartmentId",
                table: "Diagnostics",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_Id",
                table: "Diagnostics",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatients_PatientId",
                table: "DoctorPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DepartmentId",
                table: "Equipments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Id",
                table: "Equipments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Id",
                table: "Expenses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_DepartmentId",
                table: "Nurses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_Id",
                table: "Nurses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Id",
                table: "Patients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanitaries_DepartmentId",
                table: "Sanitaries",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanitaries_Id",
                table: "Sanitaries",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_DepartmentId",
                table: "Therapists",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_Id",
                table: "Therapists",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkShedcules_DoctorId_NurseId_Day",
                table: "WorkShedcules",
                columns: new[] { "DoctorId", "NurseId", "Day" },
                unique: true,
                filter: "[DoctorId] IS NOT NULL AND [NurseId] IS NOT NULL AND [Day] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShedcules_NurseId",
                table: "WorkShedcules",
                column: "NurseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostics");

            migrationBuilder.DropTable(
                name: "DoctorPatients");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "PatientAccounts");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Sanitaries");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "WorkShedcules");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
