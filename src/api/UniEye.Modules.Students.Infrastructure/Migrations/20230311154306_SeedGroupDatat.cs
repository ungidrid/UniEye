using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniEye.Modules.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedGroupDatat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "students",
                table: "StudyForm",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "FULL_TIME", "Денна" },
                    { 2, "EXTERNAL", "Заочна" }
                });

            migrationBuilder.InsertData(
                schema: "students",
                table: "Group",
                columns: new[] { "Id", "Name", "StudyFormId" },
                values: new object[,]
                {
                    { 1, "ПМІ-11", 1 },
                    { 2, "ПМІ-12", 1 },
                    { 3, "ПМІ-13", 1 },
                    { 4, "ПМІ-14", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "students",
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "Group",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "Group",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "Group",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "StudyForm",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "StudyForm",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
