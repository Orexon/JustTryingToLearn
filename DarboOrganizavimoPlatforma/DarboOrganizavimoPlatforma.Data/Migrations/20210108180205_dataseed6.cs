using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarboOrganizavimoPlatforma.Data.Migrations
{
    public partial class dataseed6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("70f1c3ed-ad48-4d49-a357-99877c2aad25"), "Admin Company", 0, "Admin Company", new DateTime(2021, 1, 8, 20, 2, 5, 515, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("dff15b08-a346-4d5e-a697-47c2b4dde94f"), "00f5abc0-cebb-47c8-ab3b-29ce1864b2b4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDateTime", "LockoutEnabled", "LockoutEnd", "MemberName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8ea4be6a-f424-4caa-b935-f63700897129"), 0, new Guid("70f1c3ed-ad48-4d49-a357-99877c2aad25"), "27747190-7b7d-453d-ba7b-5bfa31119160", "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, "AQAAAAEAACcQAAAAEOpvPVTNsK5osJyR0T+4qh/+6m4CKrv7u+KH+rrB+ptHxAyVknaIysUmJm/UTPOhkw==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8ea4be6a-f424-4caa-b935-f63700897129"), new Guid("dff15b08-a346-4d5e-a697-47c2b4dde94f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8ea4be6a-f424-4caa-b935-f63700897129"), new Guid("dff15b08-a346-4d5e-a697-47c2b4dde94f") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("dff15b08-a346-4d5e-a697-47c2b4dde94f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8ea4be6a-f424-4caa-b935-f63700897129"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("70f1c3ed-ad48-4d49-a357-99877c2aad25"));

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
    }
}
