using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHallTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalSeats_HallId",
                table: "PhysicalSeats",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_HallId",
                table: "Events",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Halls_HallId",
                table: "Events",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalSeats_Halls_HallId",
                table: "PhysicalSeats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Halls_HallId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalSeats_Halls_HallId",
                table: "PhysicalSeats");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalSeats_HallId",
                table: "PhysicalSeats");

            migrationBuilder.DropIndex(
                name: "IX_Events_HallId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("07629e44-c63f-44a9-8ff3-824748d18415"));

            migrationBuilder.DeleteData(
                table: "PhysicalSeats",
                keyColumn: "Id",
                keyValue: new Guid("15df9010-4145-41a9-af78-b3e988542ec1"));
        }
    }
}
