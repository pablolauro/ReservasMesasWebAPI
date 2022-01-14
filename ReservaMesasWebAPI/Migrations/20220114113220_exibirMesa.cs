using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    public partial class exibirMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "exibirMesa",
                table: "Mesas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exibirMesa",
                table: "Mesas");
        }
    }
}
