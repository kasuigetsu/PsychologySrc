using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFKNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_psychologist_email_address",
                table: "psychologist");

            migrationBuilder.DropIndex(
                name: "ix_psychologist_phone_number",
                table: "psychologist");

            migrationBuilder.DropIndex(
                name: "ix_psychologist_unicode",
                table: "psychologist");

            migrationBuilder.DropIndex(
                name: "ix_patients_email_address",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "ix_patients_phone_number",
                table: "patients");

            migrationBuilder.CreateIndex(
                name: "ix_psychologist_phone_number_email_address_unicode",
                table: "psychologist",
                columns: new[] { "phone_number", "email_address", "unicode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_patients_phone_number_email_address",
                table: "patients",
                columns: new[] { "phone_number", "email_address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_notifications_shedule_id",
                table: "notifications",
                column: "shedule_id");

            migrationBuilder.AddForeignKey(
                name: "fk_notifications_shedule_shedule_id",
                table: "notifications",
                column: "shedule_id",
                principalTable: "shedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notifications_shedule_shedule_id",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "ix_psychologist_phone_number_email_address_unicode",
                table: "psychologist");

            migrationBuilder.DropIndex(
                name: "ix_patients_phone_number_email_address",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "ix_notifications_shedule_id",
                table: "notifications");

            migrationBuilder.CreateIndex(
                name: "ix_psychologist_email_address",
                table: "psychologist",
                column: "email_address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_psychologist_phone_number",
                table: "psychologist",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_psychologist_unicode",
                table: "psychologist",
                column: "unicode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_patients_email_address",
                table: "patients",
                column: "email_address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_patients_phone_number",
                table: "patients",
                column: "phone_number",
                unique: true);
        }
    }
}
