using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fins",
                keyColumn: "Id",
                keyValue: 136,
                column: "Size",
                value: "XL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fins",
                keyColumn: "Id",
                keyValue: 136,
                column: "Size",
                value: "L");
        }
    }
}
