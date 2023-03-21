using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsButikMedEF.Migrations
{
    /// <inheritdoc />
    public partial class First3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beskrivelse",
                table: "Varer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bemærkninger",
                table: "Bestillinger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beskrivelse",
                table: "Varer");

            migrationBuilder.DropColumn(
                name: "Bemærkninger",
                table: "Bestillinger");
        }
    }
}
