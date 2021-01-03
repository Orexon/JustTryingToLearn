using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class projectTeamRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Projects_ProjectId",
                schema: "Identity",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ProjectId",
                schema: "Identity",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Identity",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "ProjectTeam",
                schema: "Identity",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeam", x => new { x.ProjectId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Identity",
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Identity",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_TeamId",
                schema: "Identity",
                table: "ProjectTeam",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTeam",
                schema: "Identity");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                schema: "Identity",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProjectId",
                schema: "Identity",
                table: "Teams",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Projects_ProjectId",
                schema: "Identity",
                table: "Teams",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
