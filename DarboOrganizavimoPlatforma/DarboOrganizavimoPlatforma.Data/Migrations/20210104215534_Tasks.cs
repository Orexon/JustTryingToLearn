using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class Tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATasks",
                schema: "Identity",
                columns: table => new
                {
                    ATaskId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ATaskStatus = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CompleteTime = table.Column<DateTime>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATasks", x => x.ATaskId);
                    table.ForeignKey(
                        name: "FK_ATasks_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATasks_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "Identity",
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_AppUserId",
                schema: "Identity",
                table: "ATasks",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_AssignmentId",
                schema: "Identity",
                table: "ATasks",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATasks",
                schema: "Identity");
        }
    }
}
