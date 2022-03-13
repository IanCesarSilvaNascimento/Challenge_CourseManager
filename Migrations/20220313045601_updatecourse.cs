using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManager.Migrations
{
    public partial class updatecourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Courses",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
