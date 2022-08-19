using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics");

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("39345799-a55d-4d1c-be76-fcacd9ab01c9"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("d8b4b888-eaaa-4adb-8ddf-f4a226d42f85"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("e4c5cee7-4f3d-41d6-8b6f-976c024b4cec"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("af43393d-626b-48ef-85ad-51805c74ccff"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ef48d23f-a212-4816-aec3-f612958771b3"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0521ab81-4170-46e2-962c-f0098bf39f6e"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("fd73f38b-eefd-4a3f-84fd-981c74604e90"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d99ecc7a-a269-41f4-9365-a007dc71e052"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("8a44ef7d-9663-46a5-aed1-ffb8e3c32484"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0521ab81-4170-46e2-962c-f0098bf39f6e"), "Moderator" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("8a44ef7d-9663-46a5-aed1-ffb8e3c32484"), "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("fd73f38b-eefd-4a3f-84fd-981c74604e90"), "Member" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("af43393d-626b-48ef-85ad-51805c74ccff"), "moderator@gmail.com", "moderator", "Qwerty123", new Guid("0521ab81-4170-46e2-962c-f0098bf39f6e") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("d99ecc7a-a269-41f4-9365-a007dc71e052"), "admin@gmail.com", "admin", "Qwerty123", new Guid("8a44ef7d-9663-46a5-aed1-ffb8e3c32484") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "email", "name", "pass", "RoleId" },
                values: new object[] { new Guid("ef48d23f-a212-4816-aec3-f612958771b3"), "user@gmail.com", "user", "Qwerty123", new Guid("fd73f38b-eefd-4a3f-84fd-981c74604e90") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("39345799-a55d-4d1c-be76-fcacd9ab01c9"), new DateTime(2022, 8, 17, 16, 52, 24, 102, DateTimeKind.Local).AddTicks(4950), "Books", new Guid("d99ecc7a-a269-41f4-9365-a007dc71e052") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("d8b4b888-eaaa-4adb-8ddf-f4a226d42f85"), new DateTime(2022, 8, 17, 16, 52, 24, 102, DateTimeKind.Local).AddTicks(4904), "Games", new Guid("d99ecc7a-a269-41f4-9365-a007dc71e052") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("e4c5cee7-4f3d-41d6-8b6f-976c024b4cec"), new DateTime(2022, 8, 17, 16, 52, 24, 102, DateTimeKind.Local).AddTicks(4943), "Movies", new Guid("d99ecc7a-a269-41f4-9365-a007dc71e052") });

            migrationBuilder.AddForeignKey(
                name: "FK_topics_users_UserId",
                table: "topics",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
