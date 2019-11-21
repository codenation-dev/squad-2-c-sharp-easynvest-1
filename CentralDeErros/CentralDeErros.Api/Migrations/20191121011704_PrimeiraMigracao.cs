using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class PrimeiraMigracao : Migration
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
                name: "level",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    level = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "situacao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    situacao = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situacao", x => x.id);
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
                name: "error",
                columns: table => new
                {
                    Ambiente_Id = table.Column<int>(nullable: false),
                    Level_Id = table.Column<int>(nullable: false),
                    Situacao_Id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_error", x => new { x.Situacao_Id, x.Ambiente_Id, x.Level_Id });
                    table.UniqueConstraint("AK_error_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_error_ambiente_Ambiente_Id",
                        column: x => x.Ambiente_Id,
                        principalTable: "ambiente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_level_Level_Id",
                        column: x => x.Level_Id,
                        principalTable: "level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_situacao_Situacao_Id",
                        column: x => x.Situacao_Id,
                        principalTable: "situacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ocorrenciaerro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    origem = table.Column<string>(maxLength: 200, nullable: false),
                    detalhes = table.Column<string>(maxLength: 2000, nullable: false),
                    data_hora = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    Erro_Id = table.Column<int>(nullable: false),
                    ErrorSituacao_Id = table.Column<int>(nullable: false),
                    ErrorAmbiente_Id = table.Column<int>(nullable: false),
                    ErrorLevel_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ocorrenciaerro", x => x.id);
                    table.ForeignKey(
                        name: "FK_ocorrenciaerro_user_User_Id",
                        column: x => x.User_Id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ocorrenciaerro_error_ErrorSituacao_Id_ErrorAmbiente_Id_ErrorLevel_Id",
                        columns: x => new { x.ErrorSituacao_Id, x.ErrorAmbiente_Id, x.ErrorLevel_Id },
                        principalTable: "error",
                        principalColumns: new[] { "Situacao_Id", "Ambiente_Id", "Level_Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_error_Ambiente_Id",
                table: "error",
                column: "Ambiente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_error_Level_Id",
                table: "error",
                column: "Level_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrenciaerro_User_Id",
                table: "ocorrenciaerro",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrenciaerro_ErrorSituacao_Id_ErrorAmbiente_Id_ErrorLevel_Id",
                table: "ocorrenciaerro",
                columns: new[] { "ErrorSituacao_Id", "ErrorAmbiente_Id", "ErrorLevel_Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ocorrenciaerro");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "error");

            migrationBuilder.DropTable(
                name: "ambiente");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "situacao");
        }
    }
}
