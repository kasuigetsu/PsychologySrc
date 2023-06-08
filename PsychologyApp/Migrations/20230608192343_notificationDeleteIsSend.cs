using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class notificationDeleteIsSend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_send",
                table: "notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_send",
                table: "notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
