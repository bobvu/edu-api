using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MW.DataAccess.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                schema: "dbo",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dob",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NickName",
                schema: "dbo",
                table: "Users");
        }
    }
}
