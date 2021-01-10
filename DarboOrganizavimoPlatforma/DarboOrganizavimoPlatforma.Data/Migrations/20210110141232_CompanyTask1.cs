using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class CompanyTask1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_Companies_CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.DropIndex(
                name: "IX_ATasks_CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("239b4a97-f04b-4b47-bbfb-154d35e74a07"), new Guid("9e64519d-f47d-4519-ac6f-d414bc0ff137") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9e64519d-f47d-4519-ac6f-d414bc0ff137"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("239b4a97-f04b-4b47-bbfb-154d35e74a07"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("5108dccb-e999-4adc-9830-ef9498a837be"));

            migrationBuilder.DropColumn(
                name: "CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "Identity",
                table: "ATasks",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("660486ea-ef6d-42d0-870c-82396bbb6cc1"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 10, 16, 12, 31, 800, DateTimeKind.Local).AddTicks(2969) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f9145751-3e31-49da-83bc-8be88473c784"), "27747190-7b7d-453d-ba7b-5bfa31119160", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDateTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "Notes", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("78868282-42d2-4ef2-8a6f-5d3f2a5f7527"), 0, new Guid("660486ea-ef6d-42d0-870c-82396bbb6cc1"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, null, new DateTime(2021, 1, 10, 16, 12, 31, 800, DateTimeKind.Local).AddTicks(7869), null, null, false, null, "Mindaugas", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, null, "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("78868282-42d2-4ef2-8a6f-5d3f2a5f7527"), new Guid("f9145751-3e31-49da-83bc-8be88473c784") });

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_CompanyId",
                schema: "Identity",
                table: "ATasks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_Companies_CompanyId",
                schema: "Identity",
                table: "ATasks",
                column: "CompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_Companies_CompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.DropIndex(
                name: "IX_ATasks_CompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("78868282-42d2-4ef2-8a6f-5d3f2a5f7527"), new Guid("f9145751-3e31-49da-83bc-8be88473c784") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f9145751-3e31-49da-83bc-8be88473c784"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("78868282-42d2-4ef2-8a6f-5d3f2a5f7527"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("660486ea-ef6d-42d0-870c-82396bbb6cc1"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Identity",
                table: "ATasks");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("5108dccb-e999-4adc-9830-ef9498a837be"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 10, 16, 4, 59, 515, DateTimeKind.Local).AddTicks(5675) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9e64519d-f47d-4519-ac6f-d414bc0ff137"), "27747190-7b7d-453d-ba7b-5bfa31119160", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDateTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "Notes", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("239b4a97-f04b-4b47-bbfb-154d35e74a07"), 0, new Guid("5108dccb-e999-4adc-9830-ef9498a837be"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, null, new DateTime(2021, 1, 10, 16, 4, 59, 516, DateTimeKind.Local).AddTicks(486), null, null, false, null, "Mindaugas", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, null, "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("239b4a97-f04b-4b47-bbfb-154d35e74a07"), new Guid("9e64519d-f47d-4519-ac6f-d414bc0ff137") });

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks",
                column: "CompanyTaskCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_Companies_CompanyTaskCompanyId",
                schema: "Identity",
                table: "ATasks",
                column: "CompanyTaskCompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
