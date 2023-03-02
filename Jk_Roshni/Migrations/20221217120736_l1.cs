using Microsoft.EntityFrameworkCore.Migrations;

namespace Jk_Roshni.Migrations
{
    public partial class l1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenderId",
                table: "technicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianId",
                table: "ragistration_Complains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenderId",
                table: "ragistration_Complains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenderId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "adminLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Role = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminLogins");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropColumn(
                name: "VenderId",
                table: "technicians");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "ragistration_Complains");

            migrationBuilder.DropColumn(
                name: "VenderId",
                table: "ragistration_Complains");

            migrationBuilder.DropColumn(
                name: "VenderId",
                table: "products");
        }
    }
}
