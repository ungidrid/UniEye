using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniEye.Modules.Study.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "study");

            migrationBuilder.CreateTable(
                name: "MarkType",
                schema: "study",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                schema: "study",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    MarkTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_MarkType_MarkTypeId",
                        column: x => x.MarkTypeId,
                        principalSchema: "study",
                        principalTable: "MarkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "study",
                table: "MarkType",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "LECTURE", "Контроль на лекції", "Лекція" },
                    { 2, "SEMINAR", "Практичне/семінарське заняття", "Практична" },
                    { 3, "LAB", "Лабораторна робота", "Лабораторна" },
                    { 4, "INDIVIDUAL", "Самостійна робота", "Самостійна" },
                    { 5, "PRESENTATION", "Доповідь", "Доповідь" },
                    { 6, "RETAKE", "Перездача", "Перездача" },
                    { 7, "MODULE", "Модульна робота", "Модуль" },
                    { 8, "CONTROL", "Контрольна робота", "Контрольна" },
                    { 9, "TEST", "Тест", "Тест" },
                    { 10, "COLLOQUIUM", "Колоквіум", "Колоквіум" },
                    { 11, "EXAM", "Екзамен", "Екзамен" },
                    { 12, "ZALIK", "Залік", "Залік" },
                    { 13, "OTHER", "Інше", "Інше" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_MarkTypeId",
                schema: "study",
                table: "Mark",
                column: "MarkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentId_SubjectId",
                schema: "study",
                table: "Mark",
                columns: new[] { "StudentId", "SubjectId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark",
                schema: "study");

            migrationBuilder.DropTable(
                name: "MarkType",
                schema: "study");
        }
    }
}
