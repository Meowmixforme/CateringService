using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Migrations
{
    public partial class FixContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventDTOId",
                table: "Staffing",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventDTOId",
                table: "GuestBookings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventTypeId = table.Column<string>(type: "TEXT", nullable: true),
                    VenueReservationReference = table.Column<string>(type: "TEXT", nullable: true),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CateringMenu = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDTO", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventTypeId",
                value: "WED");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventTypeId",
                value: "PTY");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventTypeId",
                value: "PTY");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "EventTypeId",
                value: "CON");

            migrationBuilder.CreateIndex(
                name: "IX_Staffing_EventDTOId",
                table: "Staffing",
                column: "EventDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventDTOId",
                table: "GuestBookings",
                column: "EventDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_EventDTO_EventDTOId",
                table: "GuestBookings",
                column: "EventDTOId",
                principalTable: "EventDTO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffing_EventDTO_EventDTOId",
                table: "Staffing",
                column: "EventDTOId",
                principalTable: "EventDTO",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_EventDTO_EventDTOId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffing_EventDTO_EventDTOId",
                table: "Staffing");

            migrationBuilder.DropTable(
                name: "EventDTO");

            migrationBuilder.DropIndex(
                name: "IX_Staffing_EventDTOId",
                table: "Staffing");

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_EventDTOId",
                table: "GuestBookings");

            migrationBuilder.DropColumn(
                name: "EventDTOId",
                table: "Staffing");

            migrationBuilder.DropColumn(
                name: "EventDTOId",
                table: "GuestBookings");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventTypeId",
                value: "Wedding");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventTypeId",
                value: "Wedding");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventTypeId",
                value: "HenParty");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "EventTypeId",
                value: "Party");
        }
    }
}
