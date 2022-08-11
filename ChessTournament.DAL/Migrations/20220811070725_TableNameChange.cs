using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessTournament.DAL.Migrations
{
    public partial class TableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TournamentStatus",
                table: "Tournaments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TournamentCategorie",
                table: "Tournaments",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Tournaments",
                newName: "Update");

            migrationBuilder.RenameColumn(
                name: "IsWomen",
                table: "Tournaments",
                newName: "IsWomenOnly");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_Pseudo",
                table: "Members",
                column: "Pseudo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_Email",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_Pseudo",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tournaments");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Tournaments",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tournaments",
                newName: "TournamentStatus");

            migrationBuilder.RenameColumn(
                name: "IsWomenOnly",
                table: "Tournaments",
                newName: "IsWomen");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Tournaments",
                newName: "TournamentCategorie");

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
