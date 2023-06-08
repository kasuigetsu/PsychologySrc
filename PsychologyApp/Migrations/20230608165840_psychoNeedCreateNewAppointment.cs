using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class psychoNeedCreateNewAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "need_create_new_appointment",
                table: "psychologist",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "need_create_new_appointment",
                table: "psychologist");
        }
    }
}
