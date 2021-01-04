using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class Assignments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_User_AppUserId",
                schema: "Identity",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                schema: "Identity",
                table: "Assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                schema: "Identity",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "Assignment",
                schema: "Identity",
                newName: "Assignments",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_TeamId",
                schema: "Identity",
                table: "Assignments",
                newName: "IX_Assignments_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_AppUserId",
                schema: "Identity",
                table: "Assignments",
                newName: "IX_Assignments_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                schema: "Identity",
                table: "Assignments",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_User_AppUserId",
                schema: "Identity",
                table: "Assignments",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Teams_TeamId",
                schema: "Identity",
                table: "Assignments",
                column: "TeamId",
                principalSchema: "Identity",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_User_AppUserId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Teams_TeamId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Assignments",
                schema: "Identity",
                newName: "Assignment",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_TeamId",
                schema: "Identity",
                table: "Assignment",
                newName: "IX_Assignment_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AppUserId",
                schema: "Identity",
                table: "Assignment",
                newName: "IX_Assignment_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                schema: "Identity",
                table: "Assignment",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_User_AppUserId",
                schema: "Identity",
                table: "Assignment",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                schema: "Identity",
                table: "Assignment",
                column: "TeamId",
                principalSchema: "Identity",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
