using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_assignment.Migrations
{
    public partial class IncidentAccountRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IncidentId",
                table: "Account",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Incidents_IncidentId",
                table: "Account",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Incidents_IncidentId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Account_IncidentId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Account");
        }
    }
}
