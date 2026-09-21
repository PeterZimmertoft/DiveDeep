using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepWebApp.Migrations
{
    /// <inheritdoc />
    public partial class adminfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-admin-user",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGQ6yjNdMhGgwFxgREzQh5mclL2YGASMrLAtbColyu1JpaFmffKLycMIgkyghLV3DQ==", "admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-admin-user",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "admin@example.com", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPxcsLXn8kn0tnREzHlDNF2MGBT3A2u5G+wwW5bSVZC37CX1oZaYk/z8uY3B2tiZuw==", "admin@example.com" });
        }
    }
}
