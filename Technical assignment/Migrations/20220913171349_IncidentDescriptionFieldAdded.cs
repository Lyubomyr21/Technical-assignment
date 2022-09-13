using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_assignment.Migrations
{
    public partial class IncidentDescriptionFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentDescription",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentDescription",
                table: "Incidents");
        }
    }
}
