using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tut10.Migrations
{
    public partial class AddedPrescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueTime = table.Column<DateTime>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false),
                    IdDoctorNavigationIdDoctor = table.Column<int>(nullable: true),
                    IdPatient = table.Column<int>(nullable: false),
                    IdPatientNavigationIdPatient = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_IdDoctorNavigationIdDoctor",
                        column: x => x.IdDoctorNavigationIdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_IdPatientNavigationIdPatient",
                        column: x => x.IdPatientNavigationIdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctorNavigationIdDoctor",
                table: "Prescription",
                column: "IdDoctorNavigationIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatientNavigationIdPatient",
                table: "Prescription",
                column: "IdPatientNavigationIdPatient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");
        }
    }
}
