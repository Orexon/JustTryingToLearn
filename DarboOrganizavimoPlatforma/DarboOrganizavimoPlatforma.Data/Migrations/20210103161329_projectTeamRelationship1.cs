using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class projectTeamRelationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTeam_Projects_ProjectId",
                schema: "Identity",
                table: "ProjectTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTeam_Teams_TeamId",
                schema: "Identity",
                table: "ProjectTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTeam",
                schema: "Identity",
                table: "ProjectTeam");

            migrationBuilder.RenameTable(
                name: "ProjectTeam",
                schema: "Identity",
                newName: "ProjectTeams",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTeam_TeamId",
                schema: "Identity",
                table: "ProjectTeams",
                newName: "IX_ProjectTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTeams",
                schema: "Identity",
                table: "ProjectTeams",
                columns: new[] { "ProjectId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTeams_Projects_ProjectId",
                schema: "Identity",
                table: "ProjectTeams",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTeams_Teams_TeamId",
                schema: "Identity",
                table: "ProjectTeams",
                column: "TeamId",
                principalSchema: "Identity",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTeams_Projects_ProjectId",
                schema: "Identity",
                table: "ProjectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTeams_Teams_TeamId",
                schema: "Identity",
                table: "ProjectTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTeams",
                schema: "Identity",
                table: "ProjectTeams");

            migrationBuilder.RenameTable(
                name: "ProjectTeams",
                schema: "Identity",
                newName: "ProjectTeam",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTeams_TeamId",
                schema: "Identity",
                table: "ProjectTeam",
                newName: "IX_ProjectTeam_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTeam",
                schema: "Identity",
                table: "ProjectTeam",
                columns: new[] { "ProjectId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTeam_Projects_ProjectId",
                schema: "Identity",
                table: "ProjectTeam",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTeam_Teams_TeamId",
                schema: "Identity",
                table: "ProjectTeam",
                column: "TeamId",
                principalSchema: "Identity",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
