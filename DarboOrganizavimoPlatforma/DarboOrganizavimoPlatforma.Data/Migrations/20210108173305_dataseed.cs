using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5a77993f-45fd-4a03-9db5-8642cad7c894"), new Guid("a10e8a2f-cd8a-45bf-9103-c48e7fcbe2aa") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a10e8a2f-cd8a-45bf-9103-c48e7fcbe2aa"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5a77993f-45fd-4a03-9db5-8642cad7c894"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("61b9404f-be7a-47f2-8abd-88c7bf9f23b6"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("7c82c213-de69-441d-a9b9-09e53e500c88"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 33, 5, 446, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9cf6e1aa-d70d-424f-9ec9-2e40adc40db5"), "e108028b-d4f8-440f-ae73-b891dbbb6585", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c06e91c7-320d-4447-a676-404d37b349de"), 0, new Guid("7c82c213-de69-441d-a9b9-09e53e500c88"), "b5d2b91a-58bb-4700-aaf7-7652ae2a026c", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAELGBmTyA4f0QsbdyUN3p/WoJC9EUWRqb92/Ln3KZkRpqae1dHx8PjsOW+ravqljHjQ==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("c06e91c7-320d-4447-a676-404d37b349de"), new Guid("9cf6e1aa-d70d-424f-9ec9-2e40adc40db5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c06e91c7-320d-4447-a676-404d37b349de"), new Guid("9cf6e1aa-d70d-424f-9ec9-2e40adc40db5") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9cf6e1aa-d70d-424f-9ec9-2e40adc40db5"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c06e91c7-320d-4447-a676-404d37b349de"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("7c82c213-de69-441d-a9b9-09e53e500c88"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyDescription", "CompanyMemberSize", "CompanyName", "CreateTime" },
                values: new object[] { new Guid("61b9404f-be7a-47f2-8abd-88c7bf9f23b6"), "Admin Company", 0, "Admin Company", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a10e8a2f-cd8a-45bf-9103-c48e7fcbe2aa"), "9888bf12-780d-426a-b164-b1dda59f05c2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5a77993f-45fd-4a03-9db5-8642cad7c894"), 0, new Guid("61b9404f-be7a-47f2-8abd-88c7bf9f23b6"), "bde6ba06-6592-4843-ae93-0611a42822c3", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAEFhW7dFxsPCIOKVyuGGo4hVXv+dARTZ0ewyU1hhVVyZN0WgddrhXkjd44o/MJampyg==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("5a77993f-45fd-4a03-9db5-8642cad7c894"), new Guid("a10e8a2f-cd8a-45bf-9103-c48e7fcbe2aa") });
        }
    }
}
