using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPTE_09.Migrations
{
    /// <inheritdoc />
    public partial class versao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_local",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_local", x => x.IdLocal);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_organizador",
                columns: table => new
                {
                    IdOrganizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_organizador", x => x.IdOrganizador);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_participante",
                columns: table => new
                {
                    IdParticipante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_participante", x => x.IdParticipante);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_evento",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LocalID = table.Column<int>(type: "int", nullable: false),
                    OrganizadorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_evento", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_tb_evento_tb_local_LocalID",
                        column: x => x.LocalID,
                        principalTable: "tb_local",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_evento_tb_organizador_OrganizadorID",
                        column: x => x.OrganizadorID,
                        principalTable: "tb_organizador",
                        principalColumn: "IdOrganizador",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_participante_evento",
                columns: table => new
                {
                    IdParticipanteEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdParticipante = table.Column<int>(type: "int", nullable: false),
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_participante_evento", x => x.IdParticipanteEvento);
                    table.ForeignKey(
                        name: "FK_tb_participante_evento_tb_evento_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "tb_evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_participante_evento_tb_participante_IdParticipante",
                        column: x => x.IdParticipante,
                        principalTable: "tb_participante",
                        principalColumn: "IdParticipante",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_evento_LocalID",
                table: "tb_evento",
                column: "LocalID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_evento_OrganizadorID",
                table: "tb_evento",
                column: "OrganizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_participante_evento_IdEvento",
                table: "tb_participante_evento",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_participante_evento_IdParticipante",
                table: "tb_participante_evento",
                column: "IdParticipante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_participante_evento");

            migrationBuilder.DropTable(
                name: "tb_evento");

            migrationBuilder.DropTable(
                name: "tb_participante");

            migrationBuilder.DropTable(
                name: "tb_local");

            migrationBuilder.DropTable(
                name: "tb_organizador");
        }
    }
}
