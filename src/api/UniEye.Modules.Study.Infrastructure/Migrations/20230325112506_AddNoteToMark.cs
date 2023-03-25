using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniEye.Modules.Study.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToMark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "study",
                table: "Mark",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                schema: "study",
                table: "Mark");
        }
    }
}
