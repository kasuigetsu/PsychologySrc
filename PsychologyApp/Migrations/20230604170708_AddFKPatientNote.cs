using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFKPatientNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_patient_notes_patient_id",
                table: "patient_notes",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "fk_patient_notes_patients_patient_id",
                table: "patient_notes",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_patient_notes_patients_patient_id",
                table: "patient_notes");

            migrationBuilder.DropIndex(
                name: "ix_patient_notes_patient_id",
                table: "patient_notes");
        }
    }
}
