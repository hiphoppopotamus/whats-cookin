using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsCookin.Migrations
{
    public partial class AddEmailVariableInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "User2" });
        }
    }
}
