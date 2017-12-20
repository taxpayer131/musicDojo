using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace musicDojo.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Adds",
                table: "Song",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adds",
                table: "Song",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
