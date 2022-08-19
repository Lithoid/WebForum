using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "authToken",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isConfirmed",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("4de27497-5ac3-4c70-8031-d728faacd237"), "Member" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("5e551dcb-8efa-478f-aa2c-2ce9a87e49c1"), "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "roleName" },
                values: new object[] { new Guid("98c722a8-2294-48ed-9803-956c61069b5c"), "Moderator" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "authToken", "email", "isConfirmed", "name", "pass", "RoleId" },
                values: new object[] { new Guid("16917eeb-e3d2-4449-8f16-0240754238c6"), "test", "user@gmail.com", true, "user", "Qwerty123", new Guid("4de27497-5ac3-4c70-8031-d728faacd237") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "authToken", "email", "isConfirmed", "name", "pass", "RoleId" },
                values: new object[] { new Guid("beed58df-bf14-4890-b434-71942e759585"), "test", "moderator@gmail.com", true, "moderator", "Qwerty123", new Guid("98c722a8-2294-48ed-9803-956c61069b5c") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "authToken", "email", "isConfirmed", "name", "pass", "RoleId" },
                values: new object[] { new Guid("d0f8b2f4-95ef-45f2-a5c8-4d1e87a733d7"), "test", "admin@gmail.com", true, "admin", "Qwerty123", new Guid("5e551dcb-8efa-478f-aa2c-2ce9a87e49c1") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("60c4e9ea-b14e-4a91-8eb4-3cd56d143852"), new DateTime(2022, 8, 19, 17, 25, 28, 567, DateTimeKind.Local).AddTicks(5382), "Movies", new Guid("d0f8b2f4-95ef-45f2-a5c8-4d1e87a733d7") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("dd83b9cf-a5ca-4db8-9e56-928b38c65a27"), new DateTime(2022, 8, 19, 17, 25, 28, 567, DateTimeKind.Local).AddTicks(5426), "Books", new Guid("d0f8b2f4-95ef-45f2-a5c8-4d1e87a733d7") });

            migrationBuilder.InsertData(
                table: "topics",
                columns: new[] { "Id", "dateCreated", "name", "UserId" },
                values: new object[] { new Guid("ed87ff61-0c31-4919-abc8-8601bfbf2aeb"), new DateTime(2022, 8, 19, 17, 25, 28, 567, DateTimeKind.Local).AddTicks(5348), "Games", new Guid("d0f8b2f4-95ef-45f2-a5c8-4d1e87a733d7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("60c4e9ea-b14e-4a91-8eb4-3cd56d143852"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("dd83b9cf-a5ca-4db8-9e56-928b38c65a27"));

            migrationBuilder.DeleteData(
                table: "topics",
                keyColumn: "Id",
                keyValue: new Guid("ed87ff61-0c31-4919-abc8-8601bfbf2aeb"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("16917eeb-e3d2-4449-8f16-0240754238c6"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("beed58df-bf14-4890-b434-71942e759585"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("4de27497-5ac3-4c70-8031-d728faacd237"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("98c722a8-2294-48ed-9803-956c61069b5c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d0f8b2f4-95ef-45f2-a5c8-4d1e87a733d7"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("5e551dcb-8efa-478f-aa2c-2ce9a87e49c1"));

            migrationBuilder.DropColumn(
                name: "authToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "isConfirmed",
                table: "users");

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
        }
    }
}
