using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class ErrorsSituation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_SITUATION_SituationId",
                table: "ERROR");

            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorSituationId_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorSituationId_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR");

            migrationBuilder.DropColumn(
                name: "SituationId",
                table: "ERROR");

            migrationBuilder.RenameColumn(
                name: "ErrorSituationId",
                table: "ERROR_OCCURRENCE",
                newName: "SituationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR",
                columns: new[] { "EnvironmentId", "LevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_SituationId",
                table: "ERROR_OCCURRENCE",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorEnvironmentId", "ErrorLevelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_OCCURRENCE_SITUATION_SituationId",
                table: "ERROR_OCCURRENCE",
                column: "SituationId",
                principalTable: "SITUATION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorEnvironmentId", "ErrorLevelId" },
                principalTable: "ERROR",
                principalColumns: new[] { "EnvironmentId", "LevelId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_OCCURRENCE_SITUATION_SituationId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_OCCURRENCE_SituationId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR");

            migrationBuilder.RenameColumn(
                name: "SituationId",
                table: "ERROR_OCCURRENCE",
                newName: "ErrorSituationId");

            migrationBuilder.AddColumn<int>(
                name: "SituationId",
                table: "ERROR",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR",
                columns: new[] { "SituationId", "EnvironmentId", "LevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorSituationId_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorSituationId", "ErrorEnvironmentId", "ErrorLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR",
                column: "EnvironmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_SITUATION_SituationId",
                table: "ERROR",
                column: "SituationId",
                principalTable: "SITUATION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorSituationId_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorSituationId", "ErrorEnvironmentId", "ErrorLevelId" },
                principalTable: "ERROR",
                principalColumns: new[] { "SituationId", "EnvironmentId", "LevelId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
