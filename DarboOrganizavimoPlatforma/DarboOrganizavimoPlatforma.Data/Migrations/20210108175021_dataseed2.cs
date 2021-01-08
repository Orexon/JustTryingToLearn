using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
