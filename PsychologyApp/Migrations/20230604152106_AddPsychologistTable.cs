using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPsychologistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "psychologist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    birthday_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    education_info = table.Column<string>(type: "text", nullable: false),
                    experience_info = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    weekends = table.Column<string>(type: "text", nullable: false),
                    unicode = table.Column<string>(type: "text", nullable: false),
                    is_receive_notif = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_psychologist", x => x.id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "psychologist");
        }
    }
}
