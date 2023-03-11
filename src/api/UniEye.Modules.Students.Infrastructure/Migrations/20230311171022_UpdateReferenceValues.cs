using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniEye.Modules.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReferenceValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             schema: "students",
             table: "PaymentTerm",
             keyColumn: "Id",
             keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "PaymentTerm",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                schema: "students",
                table: "PaymentTerm",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "BUDGET", "Бюджет" },
                    { 2, "CONTRACT", "Контракт" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "students",
                table: "PaymentTerm",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "students",
                table: "PaymentTerm",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
