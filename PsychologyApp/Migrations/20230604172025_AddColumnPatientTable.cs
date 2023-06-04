using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "psychologist_id",
                table: "patients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_patients_psychologist_id",
                table: "patients",
                column: "psychologist_id");

            migrationBuilder.AddForeignKey(
                name: "fk_patients_psychologist_psychologist_id",
                table: "patients",
                column: "psychologist_id",
                principalTable: "psychologist",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_patients_psychologist_psychologist_id",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "ix_patients_psychologist_id",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "psychologist_id",
                table: "patients");
        }
    }
}
