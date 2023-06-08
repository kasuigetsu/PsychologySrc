using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class notificationDelete2Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notifications_shedule_shedule_id",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "ix_notifications_shedule_id",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "shedule_id",
                table: "notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shedule_id",
                table: "notifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
    }
}
