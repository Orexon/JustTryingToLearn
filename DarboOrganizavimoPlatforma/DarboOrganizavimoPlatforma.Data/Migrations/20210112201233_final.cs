using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("f3048dd9-0ad8-447b-8c9b-7d52db0a5943"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 12, 22, 12, 32, 666, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("072f7292-79c2-4e6a-836f-d50dc45ddbfd"), "27747190-7b7d-453d-ba7b-5bfa31119160", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDateTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "Notes", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8c1f2956-698b-436e-97cb-3f858a877f96"), 0, new Guid("f3048dd9-0ad8-447b-8c9b-7d52db0a5943"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, null, new DateTime(2021, 1, 12, 22, 12, 32, 666, DateTimeKind.Local).AddTicks(9696), null, null, false, null, "Mindaugas", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, null, "IHDXOW62GL33UAOIJKMU6JBSKSBC63JJ", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8c1f2956-698b-436e-97cb-3f858a877f96"), new Guid("072f7292-79c2-4e6a-836f-d50dc45ddbfd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8c1f2956-698b-436e-97cb-3f858a877f96"), new Guid("072f7292-79c2-4e6a-836f-d50dc45ddbfd") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("072f7292-79c2-4e6a-836f-d50dc45ddbfd"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8c1f2956-698b-436e-97cb-3f858a877f96"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("f3048dd9-0ad8-447b-8c9b-7d52db0a5943"));

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
        }
    }
}
