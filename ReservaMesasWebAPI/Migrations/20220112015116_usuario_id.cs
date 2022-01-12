using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    public partial class usuario_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_loginUsuario",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_loginUsuario",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "loginUsuario",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_usuarioId",
                table: "Clientes",
                column: "usuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_usuarioId",
                table: "Clientes",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_usuarioId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_usuarioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "loginUsuario",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "login");

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
    }
}
