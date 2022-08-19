using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topics_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "topics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_posts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_posts_TopicId",
                table: "posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_UserId",
                table: "posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_topics_UserId",
                table: "topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "topics");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
