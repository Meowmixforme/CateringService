using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_EventDTO_EventDTOId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffing_EventDTO_EventDTOId",
                table: "Staffing");

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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "EventDTO",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "EventDTO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
