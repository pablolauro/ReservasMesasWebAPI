using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    public partial class usuario_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loginUsuario",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_loginUsuario",
                table: "Clientes",
                column: "loginUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_loginUsuario",
                table: "Clientes",
                column: "loginUsuario",
                principalTable: "Usuarios",
                principalColumn: "login",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_loginUsuario",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_loginUsuario",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "loginUsuario",
                table: "Clientes");
        }
    }
}
