using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    public partial class client_user_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_usuarioId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_usuarioId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "usuarioId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_usuarioId",
                table: "Clientes",
                column: "usuarioId",
                unique: true,
                filter: "[usuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_usuarioId",
                table: "Clientes",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_usuarioId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_usuarioId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "usuarioId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
