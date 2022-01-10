using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaMesas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMesas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.login);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtdlugares = table.Column<int>(type: "int", nullable: false),
                    numMesa = table.Column<int>(type: "int", nullable: false),
                    funcionando = table.Column<bool>(type: "bit", nullable: false),
                    idAreaMesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mesas_AreaMesas_idAreaMesa",
                        column: x => x.idAreaMesa,
                        principalTable: "AreaMesas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horainicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    mesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Mesas_mesaId",
                        column: x => x.mesaId,
                        principalTable: "Mesas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_idAreaMesa",
                table: "Mesas",
                column: "idAreaMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_clienteId",
                table: "Reservas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_mesaId",
                table: "Reservas",
                column: "mesaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "AreaMesas");
        }
    }
}
