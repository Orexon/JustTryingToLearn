using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("231ade3d-5977-4bcd-ab6a-ff563624f2c5"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 19, 48, 59, 769, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("69157aa7-e6b3-4e4e-a794-e51f5187293e"), "5621772e-dfa8-452f-af7f-fb4bb9b96954", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d45178ae-1710-4548-b6de-0389c5f20633"), 0, new Guid("231ade3d-5977-4bcd-ab6a-ff563624f2c5"), "452ec341-68f0-438c-8391-9fd53f2f748e", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAECXwRvfbG/8o4X3nOAB758MXXP3RGecv9LPzn3gks2ram8TqYA6r8kqAi0VRJDQkBw==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("d45178ae-1710-4548-b6de-0389c5f20633"), new Guid("69157aa7-e6b3-4e4e-a794-e51f5187293e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d45178ae-1710-4548-b6de-0389c5f20633"), new Guid("69157aa7-e6b3-4e4e-a794-e51f5187293e") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("69157aa7-e6b3-4e4e-a794-e51f5187293e"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d45178ae-1710-4548-b6de-0389c5f20633"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("231ade3d-5977-4bcd-ab6a-ff563624f2c5"));

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
    }
}
