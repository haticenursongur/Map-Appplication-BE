using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapApi1.Migrations
{
    /// <inheritdoc />
    public partial class AddWktColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "wkt",
                table: "point",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wkt",
                table: "point");
        }

    }
}
