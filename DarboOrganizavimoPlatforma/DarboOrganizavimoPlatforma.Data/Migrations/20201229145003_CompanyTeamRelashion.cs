using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class CompanyTeamRelashion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Companies_CompanyId",
                schema: "Identity",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "Identity",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Companies_CompanyId",
                schema: "Identity",
                table: "Teams",
                column: "CompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Companies_CompanyId",
                schema: "Identity",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "Identity",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Companies_CompanyId",
                schema: "Identity",
                table: "Teams",
                column: "CompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
