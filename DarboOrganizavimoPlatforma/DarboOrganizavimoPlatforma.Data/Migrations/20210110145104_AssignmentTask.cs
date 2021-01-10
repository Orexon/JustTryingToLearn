using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class AssignmentTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
