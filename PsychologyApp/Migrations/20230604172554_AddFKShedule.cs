using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFKShedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_shedule_patient_id",
                table: "shedule",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_shedule_psychologist_id",
                table: "shedule",
                column: "psychologist_id");

            migrationBuilder.CreateIndex(
                name: "ix_shedule_therapy_id",
                table: "shedule",
                column: "therapy_id");

            migrationBuilder.AddForeignKey(
                name: "fk_shedule_patients_patient_id",
                table: "shedule",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shedule_psychologist_psychologist_id",
                table: "shedule",
                column: "psychologist_id",
                principalTable: "psychologist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shedule_therapies_therapy_id",
                table: "shedule",
                column: "therapy_id",
                principalTable: "therapies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shedule_patients_patient_id",
                table: "shedule");

            migrationBuilder.DropForeignKey(
                name: "fk_shedule_psychologist_psychologist_id",
                table: "shedule");

            migrationBuilder.DropForeignKey(
                name: "fk_shedule_therapies_therapy_id",
                table: "shedule");

            migrationBuilder.DropIndex(
                name: "ix_shedule_patient_id",
                table: "shedule");

            migrationBuilder.DropIndex(
                name: "ix_shedule_psychologist_id",
                table: "shedule");

            migrationBuilder.DropIndex(
                name: "ix_shedule_therapy_id",
                table: "shedule");
        }
    }
}
