using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class codeBusketIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_code_busket_code",
                table: "code_busket");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "code_busket",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "code_busket");

            migrationBuilder.CreateIndex(
                name: "ix_code_busket_code",
                table: "code_busket",
                column: "code",
                unique: true);
        }
    }
}
