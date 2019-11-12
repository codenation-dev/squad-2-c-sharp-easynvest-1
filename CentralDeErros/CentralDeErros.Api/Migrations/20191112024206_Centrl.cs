using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class Centrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ambiente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ambiente = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ambiente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    level = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Situacaos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    situacao = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacaos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(maxLength: 200, nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    token = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ocorrenciaErro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    origem = table.Column<string>(maxLength: 200, nullable: false),
                    detalhes = table.Column<string>(maxLength: 2000, nullable: false),
                    data_hora = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ocorrenciaErro", x => x.id);
                    table.ForeignKey(
                        name: "FK_ocorrenciaErro_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "error",
                columns: table => new
                {
                    ambiente_id = table.Column<int>(nullable: false),
                    level_id = table.Column<int>(nullable: false),
                    situacao_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    AmbienteId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    SituacaoId = table.Column<int>(nullable: false),
                    ocorrencia_id = table.Column<int>(nullable: false),
                    OcorrenciaId = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_error", x => new { x.situacao_id, x.ambiente_id, x.level_id });
                    table.UniqueConstraint("AK_error_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_error_ambiente_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "ambiente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_ocorrenciaErro_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "ocorrenciaErro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_Situacaos_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacaos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_error_AmbienteId",
                table: "error",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_error_LevelId",
                table: "error",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_error_OcorrenciaId",
                table: "error",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_error_SituacaoId",
                table: "error",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrenciaErro_UserId",
                table: "ocorrenciaErro",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "error");

            migrationBuilder.DropTable(
                name: "ambiente");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "ocorrenciaErro");

            migrationBuilder.DropTable(
                name: "Situacaos");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
