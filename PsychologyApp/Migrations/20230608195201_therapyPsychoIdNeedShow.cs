using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class therapyPsychoIdNeedShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "need_show",
                table: "therapies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "psycho_id",
                table: "therapies",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "need_show",
                table: "therapies");

            migrationBuilder.DropColumn(
                name: "psycho_id",
                table: "therapies");
        }
    }
}
