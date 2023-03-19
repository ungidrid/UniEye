﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniEye.Modules.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityGuidProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityGuid",
                schema: "students",
                table: "Student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PersonalEmail",
                schema: "students",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityGuid",
                schema: "students",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PersonalEmail",
                schema: "students",
                table: "Student");
        }
    }
}
