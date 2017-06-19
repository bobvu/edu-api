using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MW.DataAccess.Migrations
{
    public partial class ThirdTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
