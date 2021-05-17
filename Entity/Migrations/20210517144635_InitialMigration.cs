using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftSighting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(maxLength: 128, nullable: true),
                    Model = table.Column<string>(maxLength: 128, nullable: true),
                    Registration = table.Column<string>(maxLength: 8, nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    DateAndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftSighting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftSighting");
        }
    }
}
