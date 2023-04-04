using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Migrations
{
    public partial class Seeded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "FirstAidQulaified", "Name", "Role" },
                values: new object[] { 1, "FNightingale@Gmail.com", false, "Florence Nightingale", "Security" });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "FirstAidQulaified", "Name", "Role" },
                values: new object[] { 2, "TTTed@hotmail.com", true, "Ted Bundy", "Bar Staff" });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "FirstAidQulaified", "Name", "Role" },
                values: new object[] { 3, "BLee@email.com", false, "Bruce Lee", "Waiter" });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "FirstAidQulaified", "Name", "Role" },
                values: new object[] { 4, "JBloggs@msn.com", true, "Joe Bloggs", "Waiter" });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staffing",
                keyColumns: new[] { "EventId", "StaffId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Staffing",
                keyColumns: new[] { "EventId", "StaffId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Staffing",
                keyColumns: new[] { "EventId", "StaffId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Staffing",
                keyColumns: new[] { "EventId", "StaffId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Staffing",
                keyColumns: new[] { "EventId", "StaffId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
