using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics");

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("3cde0281-e897-4b1a-bbc0-94723f47103c"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("96b0863c-4358-4c1b-b5ad-32f793638452"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("c9e8e922-9b1a-4002-8b4a-131c861b8247"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("92302743-69af-4ffc-a470-1e17679c742c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("f412b18e-30af-4e77-9334-347dfdfcc184"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("62f2129e-10e0-47ca-9503-6c977ddf58e3"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("7cf51824-66c3-490b-ae97-7187c7641659"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("2541701c-dfc7-4f0b-9bb3-968f444ec456"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cb9e072e-dfd4-4034-be5e-1d54d4884d03"));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("7709f148-53d9-49b4-a2c6-38eb13b20981"), "Moderator" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("c2980fbe-d56c-434e-9a5b-96e0c60ef962"), "Member" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("e28d3cdd-2733-496f-a2e2-63049373a835"), "Admin" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("032cbb67-9d6f-472a-878f-b026a9777ab0"), "user@gmail.com", "user", "Qwerty123", new Guid("c2980fbe-d56c-434e-9a5b-96e0c60ef962") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("47ef093b-54a6-4dca-a541-abcc7950e521"), "moderator@gmail.com", "moderator", "Qwerty123", new Guid("7709f148-53d9-49b4-a2c6-38eb13b20981") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("e660598e-ee24-437b-b69b-f58aa1aaaf29"), "admin@gmail.com", "admin", "Qwerty123", new Guid("e28d3cdd-2733-496f-a2e2-63049373a835") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("d37f55a9-8911-4e9e-b737-ad878b29cfae"), new DateTime(2022, 8, 19, 14, 32, 51, 292, DateTimeKind.Local).AddTicks(9334), "Games", new Guid("e660598e-ee24-437b-b69b-f58aa1aaaf29") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("d5818c14-5fdc-4f4a-a49a-cd0d68208fe5"), new DateTime(2022, 8, 19, 14, 32, 51, 292, DateTimeKind.Local).AddTicks(9383), "Movies", new Guid("e660598e-ee24-437b-b69b-f58aa1aaaf29") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("f95880a6-98e1-4df2-b05f-bb63c28a958e"), new DateTime(2022, 8, 19, 14, 32, 51, 292, DateTimeKind.Local).AddTicks(9386), "Books", new Guid("e660598e-ee24-437b-b69b-f58aa1aaaf29") });

            migrationBuilder.AddForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics");

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("d37f55a9-8911-4e9e-b737-ad878b29cfae"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("d5818c14-5fdc-4f4a-a49a-cd0d68208fe5"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("f95880a6-98e1-4df2-b05f-bb63c28a958e"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("032cbb67-9d6f-472a-878f-b026a9777ab0"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("47ef093b-54a6-4dca-a541-abcc7950e521"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("7709f148-53d9-49b4-a2c6-38eb13b20981"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("c2980fbe-d56c-434e-9a5b-96e0c60ef962"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("e660598e-ee24-437b-b69b-f58aa1aaaf29"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("e28d3cdd-2733-496f-a2e2-63049373a835"));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("62f2129e-10e0-47ca-9503-6c977ddf58e3"), "Member" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("7cf51824-66c3-490b-ae97-7187c7641659"), "Moderator" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("cb9e072e-dfd4-4034-be5e-1d54d4884d03"), "Admin" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("2541701c-dfc7-4f0b-9bb3-968f444ec456"), "admin@gmail.com", "admin", "Qwerty123", new Guid("cb9e072e-dfd4-4034-be5e-1d54d4884d03") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("92302743-69af-4ffc-a470-1e17679c742c"), "moderator@gmail.com", "moderator", "Qwerty123", new Guid("7cf51824-66c3-490b-ae97-7187c7641659") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("f412b18e-30af-4e77-9334-347dfdfcc184"), "user@gmail.com", "user", "Qwerty123", new Guid("62f2129e-10e0-47ca-9503-6c977ddf58e3") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("3cde0281-e897-4b1a-bbc0-94723f47103c"), new DateTime(2022, 8, 19, 14, 31, 7, 14, DateTimeKind.Local).AddTicks(5303), "Games", new Guid("2541701c-dfc7-4f0b-9bb3-968f444ec456") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("96b0863c-4358-4c1b-b5ad-32f793638452"), new DateTime(2022, 8, 19, 14, 31, 7, 14, DateTimeKind.Local).AddTicks(5335), "Movies", new Guid("2541701c-dfc7-4f0b-9bb3-968f444ec456") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("c9e8e922-9b1a-4002-8b4a-131c861b8247"), new DateTime(2022, 8, 19, 14, 31, 7, 14, DateTimeKind.Local).AddTicks(5341), "Books", new Guid("2541701c-dfc7-4f0b-9bb3-968f444ec456") });

            migrationBuilder.AddForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
