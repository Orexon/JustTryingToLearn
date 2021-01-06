using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class Task1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_User_AppUserId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                schema: "Identity",
                table: "ATasks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_User_AppUserId",
                schema: "Identity",
                table: "ATasks",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_User_AppUserId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                schema: "Identity",
                table: "ATasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_User_AppUserId",
                schema: "Identity",
                table: "ATasks",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
