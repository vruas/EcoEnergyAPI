using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoEnergyAPI.Migrations
{
    /// <inheritdoc />
    public partial class EnergyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_LUZ",
                columns: table => new
                {
                    IdContaLuz = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Regiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Mes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DiasNoMes = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    TarifaKWh = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    ClasseConsumo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Impostos = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    ValorConta = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_LUZ", x => x.IdContaLuz);
                    table.ForeignKey(
                        name: "FK_CONTA_LUZ_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DISPOSITIVO",
                columns: table => new
                {
                    IdDispositivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDispositivo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoDispositivo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConsumoWatts = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    EstadoDispositivo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISPOSITIVO", x => x.IdDispositivo);
                    table.ForeignKey(
                        name: "FK_DISPOSITIVO_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAREFA",
                columns: table => new
                {
                    IdTarefa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFA", x => x.IdTarefa);
                    table.ForeignKey(
                        name: "FK_TAREFA_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_LUZ_UsuarioIdUsuario",
                table: "CONTA_LUZ",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DISPOSITIVO_UsuarioIdUsuario",
                table: "DISPOSITIVO",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_UsuarioIdUsuario",
                table: "TAREFA",
                column: "UsuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTA_LUZ");

            migrationBuilder.DropTable(
                name: "DISPOSITIVO");

            migrationBuilder.DropTable(
                name: "TAREFA");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
