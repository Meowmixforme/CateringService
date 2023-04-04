using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Migrations
{
    public partial class Seeded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Events",
                newName: "EventTypeId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Events",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Cancelled", "CateringMenu", "Date", "Duration", "EventTypeId", "Title", "VenueReservationReference" },
                values: new object[] { 1, false, 0, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Wedding", "John Smith's Wedding", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Cancelled", "CateringMenu", "Date", "Duration", "EventTypeId", "Title", "VenueReservationReference" },
                values: new object[] { 2, false, 0, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0), "Wedding", "Jim Phillips' Golf Club Bash", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Cancelled", "CateringMenu", "Date", "Duration", "EventTypeId", "Title", "VenueReservationReference" },
                values: new object[] { 3, false, 0, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0), "HenParty", "Silly Sally's Hen Party", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Cancelled", "CateringMenu", "Date", "Duration", "EventTypeId", "Title", "VenueReservationReference" },
                values: new object[] { 4, false, 0, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 30, 0, 0), "Party", "Mike Trouble's Prison Release Party", null });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Deleted", "EmailAddress", "Forename", "Payment", "Surname" },
                values: new object[] { 1, false, "JSmith@outlook.com", "John", 123456, "Smith" });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Deleted", "EmailAddress", "Forename", "Payment", "Surname" },
                values: new object[] { 2, false, "JPhillips@hotmail.com", "Jim", 1234567, "Phillips" });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Deleted", "EmailAddress", "Forename", "Payment", "Surname" },
                values: new object[] { 3, false, "SillySally@googlemail.com", "Sally", 2345678, "Simpson" });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Deleted", "EmailAddress", "Forename", "Payment", "Surname" },
                values: new object[] { 4, true, "MTrouble@protonmail.com", "Mike", 654321, "Trouble" });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "EventId", "GuestId", "Attended" },
                values: new object[] { 1, 1, true });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "EventId", "GuestId", "Attended" },
                values: new object[] { 2, 2, true });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "EventId", "GuestId", "Attended" },
                values: new object[] { 3, 3, false });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "EventId", "GuestId", "Attended" },
                values: new object[] { 4, 4, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "Events",
                newName: "TypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(TimeSpan),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
