using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniEye.Modules.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveNameToOwnedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "students",
                table: "Student",
                newName: "Name_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "students",
                table: "Student",
                newName: "Name_FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "students",
                table: "StudyForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "students",
                table: "PaymentTerm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "students",
                table: "PaymentTerm",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "students",
                table: "PaymentTerm",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "students",
                table: "StudyForm",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "students",
                table: "StudyForm",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "students",
                table: "StudyForm");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "students",
                table: "PaymentTerm");

            migrationBuilder.RenameColumn(
                name: "Name_LastName",
                schema: "students",
                table: "Student",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name_FirstName",
                schema: "students",
                table: "Student",
                newName: "FirstName");
        }
    }
}
