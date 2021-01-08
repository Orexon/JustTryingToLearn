using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("06051660-4eda-4bad-a63a-06f0fa38f3ab"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 56, 33, 199, DateTimeKind.Local).AddTicks(7051) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("dc7b7468-e167-4b09-830a-36ac5e3aa5b2"), "8995dee6-fee9-4188-b935-e257212dc817", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ac2c8c23-130e-436d-96c0-6d7110aa5068"), 0, new Guid("06051660-4eda-4bad-a63a-06f0fa38f3ab"), "e44436fc-7ad3-4619-bd6f-cda903b2cc78", "admin@admin", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAEBLJPZ1L4AVjo7JH8l1O2QW1D3VxO6jm+Vk0FG1uCUCHMs6jNI9RDpwL5yb0sj/AEA==", null, false, null, false, "admin@admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("ac2c8c23-130e-436d-96c0-6d7110aa5068"), new Guid("dc7b7468-e167-4b09-830a-36ac5e3aa5b2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("ac2c8c23-130e-436d-96c0-6d7110aa5068"), new Guid("dc7b7468-e167-4b09-830a-36ac5e3aa5b2") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("dc7b7468-e167-4b09-830a-36ac5e3aa5b2"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ac2c8c23-130e-436d-96c0-6d7110aa5068"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("06051660-4eda-4bad-a63a-06f0fa38f3ab"));

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
    }
}
