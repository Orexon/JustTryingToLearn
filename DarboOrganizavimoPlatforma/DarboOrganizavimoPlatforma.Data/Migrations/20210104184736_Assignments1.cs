using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class Assignments1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                schema: "Identity",
                table: "Assignment");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                schema: "Identity",
                table: "Assignment",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                schema: "Identity",
                table: "Assignment");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                schema: "Identity",
                table: "Assignment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                schema: "Identity",
                table: "Assignment",
                column: "TeamId",
                principalSchema: "Identity",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
