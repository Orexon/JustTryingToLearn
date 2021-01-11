using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class CompanyAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d1d2b97f-69e0-4e01-a36f-fc20448e0568"), new Guid("674dbadf-8b93-4c18-9296-aeab7dd4d322") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("674dbadf-8b93-4c18-9296-aeab7dd4d322"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d1d2b97f-69e0-4e01-a36f-fc20448e0568"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c90f5069-15e9-47b7-8c7c-156cd1a61c49"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "Identity",
                table: "Assignments",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("3768038d-91af-4052-b0f3-d8257ef2bddb"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 11, 9, 8, 37, 29, DateTimeKind.Local).AddTicks(6337) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e0ff5917-ed14-4bee-b90d-4b6278fb195e"), "27747190-7b7d-453d-ba7b-5bfa31119160", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDateTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "Notes", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bfcba01a-e31b-4686-9207-c8f97f85ab5a"), 0, new Guid("3768038d-91af-4052-b0f3-d8257ef2bddb"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, null, new DateTime(2021, 1, 11, 9, 8, 37, 30, DateTimeKind.Local).AddTicks(1072), null, null, false, null, "Mindaugas", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, null, "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("bfcba01a-e31b-4686-9207-c8f97f85ab5a"), new Guid("e0ff5917-ed14-4bee-b90d-4b6278fb195e") });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CompanyId",
                schema: "Identity",
                table: "Assignments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Companies_CompanyId",
                schema: "Identity",
                table: "Assignments",
                column: "CompanyId",
                principalSchema: "Identity",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Companies_CompanyId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CompanyId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("bfcba01a-e31b-4686-9207-c8f97f85ab5a"), new Guid("e0ff5917-ed14-4bee-b90d-4b6278fb195e") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e0ff5917-ed14-4bee-b90d-4b6278fb195e"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bfcba01a-e31b-4686-9207-c8f97f85ab5a"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3768038d-91af-4052-b0f3-d8257ef2bddb"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Identity",
                table: "Assignments");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("c90f5069-15e9-47b7-8c7c-156cd1a61c49"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 10, 16, 51, 4, 343, DateTimeKind.Local).AddTicks(2923) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("674dbadf-8b93-4c18-9296-aeab7dd4d322"), "27747190-7b7d-453d-ba7b-5bfa31119160", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDateTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "Notes", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d1d2b97f-69e0-4e01-a36f-fc20448e0568"), 0, new Guid("c90f5069-15e9-47b7-8c7c-156cd1a61c49"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, null, new DateTime(2021, 1, 10, 16, 51, 4, 343, DateTimeKind.Local).AddTicks(9007), null, null, false, null, "Mindaugas", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, null, "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("d1d2b97f-69e0-4e01-a36f-fc20448e0568"), new Guid("674dbadf-8b93-4c18-9296-aeab7dd4d322") });
        }
    }
}
