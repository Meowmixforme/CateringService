using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Migrations
{
    public partial class _4534 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodBookingId",
                table: "Events",
                newName: "CateringMenu");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Events",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CateringMenu",
                table: "Events",
                newName: "FoodBookingId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Events",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
