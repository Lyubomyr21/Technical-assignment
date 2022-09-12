using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_assignment.Migrations
{
    public partial class AccountContactRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountId",
                table: "Contacts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Account_AccountId",
                table: "Contacts",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Account_AccountId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AccountId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Contacts");
        }
    }
}
