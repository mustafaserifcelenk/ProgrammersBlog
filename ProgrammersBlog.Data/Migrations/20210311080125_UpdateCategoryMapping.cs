using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersBlog.Data.Migrations
{
    public partial class UpdateCategoryMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 676, DateTimeKind.Local).AddTicks(8505), new DateTime(2021, 3, 11, 11, 1, 24, 676, DateTimeKind.Local).AddTicks(6707), new DateTime(2021, 3, 11, 11, 1, 24, 676, DateTimeKind.Local).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1798), new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1795), new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1809), new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1807), new DateTime(2021, 3, 11, 11, 1, 24, 677, DateTimeKind.Local).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2833), new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2866), new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2867) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2872), new DateTime(2021, 3, 11, 11, 1, 24, 680, DateTimeKind.Local).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5708), new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5722) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5739), new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5740) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5745), new DateTime(2021, 3, 11, 11, 1, 24, 682, DateTimeKind.Local).AddTicks(5747) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 684, DateTimeKind.Local).AddTicks(4004), new DateTime(2021, 3, 11, 11, 1, 24, 684, DateTimeKind.Local).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 1, 24, 698, DateTimeKind.Local).AddTicks(197), new DateTime(2021, 3, 11, 11, 1, 24, 698, DateTimeKind.Local).AddTicks(215) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(1160), new DateTime(2021, 3, 7, 21, 14, 17, 795, DateTimeKind.Local).AddTicks(9003), new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4787), new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4783), new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4789) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4796), new DateTime(2021, 3, 7, 21, 14, 17, 796, DateTimeKind.Local).AddTicks(4802) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1830), new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1853) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1875), new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1882), new DateTime(2021, 3, 7, 21, 14, 17, 802, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(790), new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(834), new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(841), new DateTime(2021, 3, 7, 21, 14, 17, 805, DateTimeKind.Local).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 807, DateTimeKind.Local).AddTicks(3763), new DateTime(2021, 3, 7, 21, 14, 17, 807, DateTimeKind.Local).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 14, 17, 825, DateTimeKind.Local).AddTicks(1414), new DateTime(2021, 3, 7, 21, 14, 17, 825, DateTimeKind.Local).AddTicks(1444) });
        }
    }
}
