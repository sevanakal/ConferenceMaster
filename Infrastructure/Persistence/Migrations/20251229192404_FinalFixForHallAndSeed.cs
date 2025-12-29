using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixForHallAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("07629e44-c63f-44a9-8ff3-824748d18415"));

            migrationBuilder.DeleteData(
                table: "PhysicalSeats",
                keyColumn: "Id",
                keyValue: new Guid("15df9010-4145-41a9-af78-b3e988542ec1"));

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: new Guid("e4b38eef-7890-4e7a-bec5-5fc0e230e881"));

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), 100, "Mavi Salon" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "HallId", "IsPaid", "Name", "StartTime" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), true, "Tech Conference 2024", new DateTime(2024, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PhysicalSeats",
                columns: new[] { "Id", "CoordX", "CoordY", "DelegatedUserId", "HallId", "Number", "ResponsibleUserId", "RowName" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), 10, 20, null, new Guid("11111111-1111-1111-1111-111111111111"), 1, null, "A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "PhysicalSeats",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("e4b38eef-7890-4e7a-bec5-5fc0e230e881"), 100, "Mavi Salon" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "HallId", "IsPaid", "Name", "StartTime" },
                values: new object[] { new Guid("07629e44-c63f-44a9-8ff3-824748d18415"), new Guid("e4b38eef-7890-4e7a-bec5-5fc0e230e881"), true, "Tech Conference 2024", new DateTime(2024, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PhysicalSeats",
                columns: new[] { "Id", "CoordX", "CoordY", "DelegatedUserId", "HallId", "Number", "ResponsibleUserId", "RowName" },
                values: new object[] { new Guid("15df9010-4145-41a9-af78-b3e988542ec1"), 10, 20, null, new Guid("e4b38eef-7890-4e7a-bec5-5fc0e230e881"), 1, null, "A" });
        }
    }
}
