using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WorkDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSchedule");

            migrationBuilder.CreateTable(
                name: "DiagnosticWorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosticId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticWorkDays_Diagnostics_DiagnosticId",
                        column: x => x.DiagnosticId,
                        principalTable: "Diagnostics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentWorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentWorkDays_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseWorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseWorkDays_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanitaryWorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanitaryId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanitaryWorkDays_Sanitaries_SanitaryId",
                        column: x => x.SanitaryId,
                        principalTable: "Sanitaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistWorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapistId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistWorkDays_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosticWorkDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticWorkHours_DiagnosticWorkDays_DiagnosticWorkDayId",
                        column: x => x.DiagnosticWorkDayId,
                        principalTable: "DiagnosticWorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentWorkDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentWorkHours_EquipmentWorkDays_EquipmentWorkDayId",
                        column: x => x.EquipmentWorkDayId,
                        principalTable: "EquipmentWorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseWorkDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseWorkHours_NurseWorkDays_NurseWorkDayId",
                        column: x => x.NurseWorkDayId,
                        principalTable: "NurseWorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanitaryWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanitaryWorkDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanitaryWorkHours_SanitaryWorkDays_SanitaryWorkDayId",
                        column: x => x.SanitaryWorkDayId,
                        principalTable: "SanitaryWorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapistWorkDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistWorkHours_TherapistWorkDays_TherapistWorkDayId",
                        column: x => x.TherapistWorkDayId,
                        principalTable: "TherapistWorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticWorkDays_DiagnosticId",
                table: "DiagnosticWorkDays",
                column: "DiagnosticId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticWorkHours_DiagnosticWorkDayId",
                table: "DiagnosticWorkHours",
                column: "DiagnosticWorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentWorkDays_EquipmentId",
                table: "EquipmentWorkDays",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentWorkHours_EquipmentWorkDayId",
                table: "EquipmentWorkHours",
                column: "EquipmentWorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseWorkDays_NurseId",
                table: "NurseWorkDays",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseWorkHours_NurseWorkDayId",
                table: "NurseWorkHours",
                column: "NurseWorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitaryWorkDays_SanitaryId",
                table: "SanitaryWorkDays",
                column: "SanitaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitaryWorkHours_SanitaryWorkDayId",
                table: "SanitaryWorkHours",
                column: "SanitaryWorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistWorkDays_TherapistId",
                table: "TherapistWorkDays",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistWorkHours_TherapistWorkDayId",
                table: "TherapistWorkHours",
                column: "TherapistWorkDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticWorkHours");

            migrationBuilder.DropTable(
                name: "EquipmentWorkHours");

            migrationBuilder.DropTable(
                name: "NurseWorkHours");

            migrationBuilder.DropTable(
                name: "SanitaryWorkHours");

            migrationBuilder.DropTable(
                name: "TherapistWorkHours");

            migrationBuilder.DropTable(
                name: "DiagnosticWorkDays");

            migrationBuilder.DropTable(
                name: "EquipmentWorkDays");

            migrationBuilder.DropTable(
                name: "NurseWorkDays");

            migrationBuilder.DropTable(
                name: "SanitaryWorkDays");

            migrationBuilder.DropTable(
                name: "TherapistWorkDays");

            migrationBuilder.CreateTable(
                name: "WorkSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedule_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkSchedule_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedule_DoctorId",
                table: "WorkSchedule",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedule_NurseId",
                table: "WorkSchedule",
                column: "NurseId");
        }
    }
}
