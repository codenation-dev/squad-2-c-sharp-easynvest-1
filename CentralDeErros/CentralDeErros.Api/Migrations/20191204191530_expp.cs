﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class expp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EXPIRATION",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EXPIRATION",
                table: "USERS");
        }
    }
}
