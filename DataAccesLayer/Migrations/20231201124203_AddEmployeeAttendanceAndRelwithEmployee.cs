using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeAttendanceAndRelwithEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmpAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    attendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPresent = table.Column<int>(type: "int", nullable: false),
                    isAbsent = table.Column<int>(type: "int", nullable: false),
                    isOffday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpAttendances_tblEmployees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAttendances_employeeId",
                table: "tblEmpAttendances",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmpAttendances");
        }
    }
}
