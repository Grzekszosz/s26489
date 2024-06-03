using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "APDBP");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                schema: "APDB",
                newName: "Prescriptions",
                newSchema: "APDBP");

            migrationBuilder.RenameTable(
                name: "PrescriptionMedicaments",
                schema: "APDB",
                newName: "PrescriptionMedicaments",
                newSchema: "APDBP");

            migrationBuilder.RenameTable(
                name: "Patients",
                schema: "APDB",
                newName: "Patients",
                newSchema: "APDBP");

            migrationBuilder.RenameTable(
                name: "Medicaments",
                schema: "APDB",
                newName: "Medicaments",
                newSchema: "APDBP");

            migrationBuilder.RenameTable(
                name: "Doctors",
                schema: "APDB",
                newName: "Doctors",
                newSchema: "APDBP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "APDB");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                schema: "APDBP",
                newName: "Prescriptions",
                newSchema: "APDB");

            migrationBuilder.RenameTable(
                name: "PrescriptionMedicaments",
                schema: "APDBP",
                newName: "PrescriptionMedicaments",
                newSchema: "APDB");

            migrationBuilder.RenameTable(
                name: "Patients",
                schema: "APDBP",
                newName: "Patients",
                newSchema: "APDB");

            migrationBuilder.RenameTable(
                name: "Medicaments",
                schema: "APDBP",
                newName: "Medicaments",
                newSchema: "APDB");

            migrationBuilder.RenameTable(
                name: "Doctors",
                schema: "APDBP",
                newName: "Doctors",
                newSchema: "APDB");
        }
    }
}
