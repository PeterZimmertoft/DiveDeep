using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepWebApp.Migrations
{
    /// <inheritdoc />
    public partial class packages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageProducts",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProducts", x => new { x.PackageId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PackageProducts_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Denne all‑around dykkerpakke er skabt til dig, der vil opleve havet med udstyr, der føles naturligt og trygt fra første sekund under overfladen. Scubapro‑kvaliteten går igen i hele sættet og giver en harmonisk pasform og stabil oplevelse, uanset hvor du dykker. Kombinationen af 5 mm dragt, Hydros Pro BCD, 12 L tank og MK25EVO/S600 regulatorsættet er en gennemprøvet opsætning, der leverer både komfort og sikkerhed. Masken og finnerne er valgt for deres fleksibilitet og lette håndtering, så både nye og erfarne dykkere kan glide ubesværet gennem vandet. En stærk, velafbalanceret pakke til dig, der vil dykke dybt — og dykke godt.", new byte[0], "Komplet dykkersæt" },
                    { 2, "Denne pakke er skabt til dig, der vil udforske havet med udstyr, der føles let, behageligt og intuitivt fra første øjeblik. Masken og snorklen giver høj komfort og en pasform, der gør det nemt at fokusere på oplevelsen under overfladen, mens finnerne leverer en jævn, kraftfuld fremdrift, uanset om du snorkler langs kysten eller dykker ned i det blå. Hele sættet er let, robust og nemt at transportere, så du kan tage det med på både små og store eventyr. Du får premium kvalitet, der løfter oplevelsen — uden at prisen løber løbsk.", new byte[0], "Komplet snorkelsæt" }
                });

            migrationBuilder.InsertData(
                table: "PackageProducts",
                columns: new[] { "PackageId", "ProductId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 1, 13 },
                    { 1, 95 },
                    { 1, 97 },
                    { 1, 101 },
                    { 1, 117 },
                    { 2, 101 },
                    { 2, 117 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageProducts_ProductId",
                table: "PackageProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageProducts");

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
