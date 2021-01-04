using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class AssignmentsRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_User_AppUserId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AppUserId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "AssingmentStatus",
                schema: "Identity",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAssingments",
                schema: "Identity",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(nullable: false),
                    AssingmentId = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAssingments",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "AssingmentStatus",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                schema: "Identity",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                schema: "Identity",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AppUserId",
                schema: "Identity",
                table: "Assignments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_User_AppUserId",
                schema: "Identity",
                table: "Assignments",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
