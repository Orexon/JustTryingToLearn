using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d507c6fb-6d60-4bde-8572-1d4b46efd856"), new Guid("cb2688fa-d162-4011-9b00-88347011adab") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cb2688fa-d162-4011-9b00-88347011adab"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d507c6fb-6d60-4bde-8572-1d4b46efd856"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("ec4a0913-92b3-45a8-b2e4-bc1a017b4c0f"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("4a929688-51d4-46b3-aad4-9388b59980bb"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 51, 27, 261, DateTimeKind.Local).AddTicks(7397) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bb46eb5a-c74b-4387-baf9-63fab677d795"), "b6a02615-6fc4-4c7e-8821-0a114de98d7a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("18cca4d6-8d7b-4939-a51f-480c7bec692c"), 0, new Guid("4a929688-51d4-46b3-aad4-9388b59980bb"), "43e83fb8-e153-40b6-8574-2c99e763789e", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAEEjlruzlJnU0NLl20DJe1KECCWEZZDshUsEyxgiHwFp/DjvCD15Jo1/ZFLhOFbniZw==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("18cca4d6-8d7b-4939-a51f-480c7bec692c"), new Guid("bb46eb5a-c74b-4387-baf9-63fab677d795") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("18cca4d6-8d7b-4939-a51f-480c7bec692c"), new Guid("bb46eb5a-c74b-4387-baf9-63fab677d795") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bb46eb5a-c74b-4387-baf9-63fab677d795"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18cca4d6-8d7b-4939-a51f-480c7bec692c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("4a929688-51d4-46b3-aad4-9388b59980bb"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("ec4a0913-92b3-45a8-b2e4-bc1a017b4c0f"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 50, 21, 474, DateTimeKind.Local).AddTicks(619) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cb2688fa-d162-4011-9b00-88347011adab"), "1426e59e-b403-4923-99a8-7b4ce29c2371", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d507c6fb-6d60-4bde-8572-1d4b46efd856"), 0, new Guid("ec4a0913-92b3-45a8-b2e4-bc1a017b4c0f"), "264bb58b-3240-4882-afeb-63193b2c6aa1", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAEN1EvVMLXw+dRBCKC1zz6/6mm3LTRAywatwg7uWTAT6ABCOIAnQyDs3ZN8r+sW0eGw==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("d507c6fb-6d60-4bde-8572-1d4b46efd856"), new Guid("cb2688fa-d162-4011-9b00-88347011adab") });
        }
    }
}
