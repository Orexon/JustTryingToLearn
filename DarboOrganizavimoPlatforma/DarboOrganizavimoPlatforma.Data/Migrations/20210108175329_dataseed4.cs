using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("5d60a334-7e82-4998-8d84-8849dc71c80e"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 53, 29, 394, DateTimeKind.Local).AddTicks(2033) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b388b16b-1f80-48de-ab8f-e45164e4fc1c"), "1e5bc67b-ed97-4dfe-acb7-6376ea2aeb67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c29d312c-a35b-483f-98ad-4e0ba2da51c6"), 0, new Guid("5d60a334-7e82-4998-8d84-8849dc71c80e"), "f39bf4c8-7b52-4c0f-be15-2a974260a384", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAENbVpQ9nkwJwvOn9RH//p9U2jZvINiwR2feY1trHZ6bkhVupgmT+HUpGsy/yY5jPog==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("c29d312c-a35b-483f-98ad-4e0ba2da51c6"), new Guid("b388b16b-1f80-48de-ab8f-e45164e4fc1c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c29d312c-a35b-483f-98ad-4e0ba2da51c6"), new Guid("b388b16b-1f80-48de-ab8f-e45164e4fc1c") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b388b16b-1f80-48de-ab8f-e45164e4fc1c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c29d312c-a35b-483f-98ad-4e0ba2da51c6"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("5d60a334-7e82-4998-8d84-8849dc71c80e"));

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
    }
}
