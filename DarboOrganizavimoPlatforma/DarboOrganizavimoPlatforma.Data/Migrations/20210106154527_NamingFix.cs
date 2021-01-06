using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class NamingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAssingments",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "AssingmentStatus",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentStatus",
                schema: "Identity",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAssignments",
                schema: "Identity",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssignments", x => new { x.AppUserId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_UserAssignments_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "Identity",
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAssignments_AssignmentId",
                schema: "Identity",
                table: "UserAssignments",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAssignments",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "AssignmentStatus",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "AssingmentStatus",
                schema: "Identity",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAssingments",
                schema: "Identity",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssingmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssingments", x => new { x.AppUserId, x.AssingmentId });
                    table.ForeignKey(
                        name: "FK_UserAssingments_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAssingments_Assignments_AssingmentId",
                        column: x => x.AssingmentId,
                        principalSchema: "Identity",
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAssingments_AssingmentId",
                schema: "Identity",
                table: "UserAssingments",
                column: "AssingmentId");
        }
    }
}
