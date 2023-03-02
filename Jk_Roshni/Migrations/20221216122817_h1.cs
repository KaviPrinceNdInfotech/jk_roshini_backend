using Microsoft.EntityFrameworkCore.Migrations;

namespace Jk_Roshni.Migrations
{
    public partial class h1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rgx",
                table: "ragistration_Complains",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rgx",
                table: "ragistration_Complains");
        }
    }
}
