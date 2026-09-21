using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCDs_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fins_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Masks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Masks_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regulators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regulators_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suits_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "", new byte[0], "BCD" },
                    { 2, "", new byte[0], "Dykkerdragter" },
                    { 3, "", new byte[0], "Tanke" },
                    { 4, "", new byte[0], "Regulatorsæt" },
                    { 5, "", new byte[0], "Maske/Snorkel" },
                    { 6, "", new byte[0], "Finner" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "Image", "Price" },
                values: new object[,]
                {
                    { 1, "Scubapro", 1, "", new byte[0], 125.0 },
                    { 2, "Scubapro", 1, "", new byte[0], 125.0 },
                    { 3, "Scubapro", 1, "", new byte[0], 125.0 },
                    { 4, "Scubapro", 1, "", new byte[0], 140.0 },
                    { 5, "Scubapro", 1, "", new byte[0], 140.0 },
                    { 6, "Scubapro", 1, "", new byte[0], 140.0 },
                    { 7, "Scubapro", 1, "", new byte[0], 200.0 },
                    { 8, "Scubapro", 1, "", new byte[0], 200.0 },
                    { 9, "Scubapro", 1, "", new byte[0], 200.0 },
                    { 10, "Seac", 1, "", new byte[0], 145.0 },
                    { 11, "Seac", 1, "", new byte[0], 145.0 },
                    { 12, "Seac", 1, "", new byte[0], 145.0 },
                    { 13, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 14, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 15, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 16, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 17, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 18, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 19, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 20, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 21, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 22, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 23, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 24, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 25, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 26, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 27, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 28, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 29, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 30, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 31, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 32, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 33, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 34, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 35, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 36, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 37, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 38, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 39, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 40, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 41, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 42, "Scubapro", 2, "", new byte[0], 100.0 },
                    { 43, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 44, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 45, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 46, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 47, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 48, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 49, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 50, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 51, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 52, "Waterproof", 2, "", new byte[0], 100.0 },
                    { 53, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 54, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 55, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 56, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 57, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 58, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 59, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 60, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 61, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 62, "Fourth Element", 2, "", new byte[0], 120.0 },
                    { 63, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 64, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 65, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 66, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 67, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 68, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 69, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 70, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 71, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 72, "Scubapro", 2, "", new byte[0], 300.0 },
                    { 73, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 74, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 75, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 76, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 77, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 78, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 79, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 80, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 81, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 82, "Waterproof", 2, "", new byte[0], 320.0 },
                    { 83, "Santi", 2, "", new byte[0], 350.0 },
                    { 84, "Santi", 2, "", new byte[0], 350.0 },
                    { 85, "Santi", 2, "", new byte[0], 350.0 },
                    { 86, "Santi", 2, "", new byte[0], 350.0 },
                    { 87, "Santi", 2, "", new byte[0], 350.0 },
                    { 88, "Santi", 2, "", new byte[0], 350.0 },
                    { 89, "Santi", 2, "", new byte[0], 350.0 },
                    { 90, "Santi", 2, "", new byte[0], 350.0 },
                    { 91, "Santi", 2, "", new byte[0], 350.0 },
                    { 92, "Santi", 2, "", new byte[0], 350.0 },
                    { 93, "Scubapro", 3, "", new byte[0], 150.0 },
                    { 94, "Scubapro", 3, "", new byte[0], 160.0 },
                    { 95, "Scubapro", 3, "", new byte[0], 170.0 },
                    { 96, "Scubapro", 3, "", new byte[0], 180.0 },
                    { 97, "Scubapro", 4, "", new byte[0], 125.0 },
                    { 98, "Scubapro", 4, "", new byte[0], 100.0 },
                    { 99, "Scubapro", 4, "", new byte[0], 150.0 },
                    { 100, "Scubapro", 5, "", new byte[0], 50.0 },
                    { 101, "Scubapro", 5, "", new byte[0], 60.0 },
                    { 102, "Scubapro", 5, "", new byte[0], 50.0 },
                    { 103, "Scubapro", 5, "", new byte[0], 75.0 },
                    { 104, "Fourth Element", 5, "", new byte[0], 75.0 },
                    { 105, "Fourth Element", 5, "", new byte[0], 75.0 },
                    { 106, "Tusa", 5, "", new byte[0], 75.0 },
                    { 107, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 108, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 109, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 110, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 111, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 112, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 113, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 114, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 115, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 116, "Scubapro", 6, "", new byte[0], 50.0 },
                    { 117, "Scubapro", 6, "", new byte[0], 60.0 },
                    { 118, "Scubapro", 6, "", new byte[0], 60.0 },
                    { 119, "Scubapro", 6, "", new byte[0], 60.0 },
                    { 120, "Scubapro", 6, "", new byte[0], 60.0 },
                    { 121, "Scubapro", 6, "", new byte[0], 60.0 },
                    { 122, "Seac", 6, "", new byte[0], 50.0 },
                    { 123, "Seac", 6, "", new byte[0], 50.0 },
                    { 124, "Seac", 6, "", new byte[0], 50.0 },
                    { 125, "Seac", 6, "", new byte[0], 50.0 },
                    { 126, "Seac", 6, "", new byte[0], 50.0 },
                    { 127, "Seac", 6, "", new byte[0], 50.0 },
                    { 128, "Seac", 6, "", new byte[0], 50.0 },
                    { 129, "Seac", 6, "", new byte[0], 50.0 },
                    { 130, "Seac", 6, "", new byte[0], 50.0 },
                    { 131, "Seac", 6, "", new byte[0], 50.0 },
                    { 132, "Fourth Element", 6, "", new byte[0], 75.0 },
                    { 133, "Fourth Element", 6, "", new byte[0], 75.0 },
                    { 134, "Fourth Element", 6, "", new byte[0], 75.0 },
                    { 135, "Fourth Element", 6, "", new byte[0], 75.0 },
                    { 136, "Fourth Element", 6, "", new byte[0], 75.0 },
                    { 137, "Fourth Element", 6, "", new byte[0], 80.0 },
                    { 138, "Fourth Element", 6, "", new byte[0], 80.0 },
                    { 139, "Fourth Element", 6, "", new byte[0], 80.0 },
                    { 140, "Fourth Element", 6, "", new byte[0], 80.0 },
                    { 141, "Fourth Element", 6, "", new byte[0], 80.0 }
                });

            migrationBuilder.InsertData(
                table: "BCDs",
                columns: new[] { "Id", "Model", "Size" },
                values: new object[,]
                {
                    { 1, "Navigator Lite BCD", "S" },
                    { 2, "Navigator Lite BCD", "M" },
                    { 3, "Navigator Lite BCD", "L" },
                    { 4, "BCD Glide", "S" },
                    { 5, "BCD Glide", "M" },
                    { 6, "BCD Glide", "L" },
                    { 7, "BCD Hydros Pro", "S" },
                    { 8, "BCD Hydros Pro", "M" },
                    { 9, "BCD Hydros Pro", "L" },
                    { 10, "BCD Modular", "S" },
                    { 11, "BCD Modular", "M" },
                    { 12, "BCD Modular", "L" }
                });

            migrationBuilder.InsertData(
                table: "Fins",
                columns: new[] { "Id", "Model", "Size" },
                values: new object[,]
                {
                    { 107, "Jet Fin", "XS" },
                    { 108, "Jet Fin", "S" },
                    { 109, "Jet Fin", "M" },
                    { 110, "Jet Fin", "L" },
                    { 111, "Jet Fin", "XL" },
                    { 112, "GO Travel", "XS" },
                    { 113, "GO Travel", "S" },
                    { 114, "GO Travel", "M" },
                    { 115, "GO Travel", "L" },
                    { 116, "GO Travel", "XL" },
                    { 117, "Seawing Supernova", "XS" },
                    { 118, "Seawing Supernova", "S" },
                    { 119, "Seawing Supernova", "M" },
                    { 120, "Seawing Supernova", "L" },
                    { 121, "Seawing Supernova", "XL" },
                    { 122, "Propulsion", "XS" },
                    { 123, "Propulsion", "S" },
                    { 124, "Propulsion", "M" },
                    { 125, "Propulsion", "L" },
                    { 126, "Propulsion", "XL" },
                    { 127, "ALA", "XS" },
                    { 128, "ALA", "S" },
                    { 129, "ALA", "M" },
                    { 130, "ALA", "L" },
                    { 131, "ALA", "XL" },
                    { 132, "Tech", "XS" },
                    { 133, "Tech", "S" },
                    { 134, "Tech", "M" },
                    { 135, "Tech", "L" },
                    { 136, "Tech", "L" },
                    { 137, "Rec Fin", "XS" },
                    { 138, "Rec Fin", "S" },
                    { 139, "Rec Fin", "M" },
                    { 140, "Rec Fin", "L" },
                    { 141, "Rec Fin", "XL" }
                });

            migrationBuilder.InsertData(
                table: "Masks",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 100, "Ghost" },
                    { 101, "D-Mask" },
                    { 102, "Spectra Mini" },
                    { 103, "Crystal VU" },
                    { 104, "Scout Kontrast" },
                    { 105, "Scout Enhance" },
                    { 106, "Element" }
                });

            migrationBuilder.InsertData(
                table: "Regulators",
                columns: new[] { "Id", "FirstStage", "Octopus", "SecondStage" },
                values: new object[,]
                {
                    { 97, "MK25EVO", "R105", "S600" },
                    { 98, "MK17EVO", "R095", "C370" },
                    { 99, "MK25EVO BT", "S270", "A700 Carbon BT" }
                });

            migrationBuilder.InsertData(
                table: "Suits",
                columns: new[] { "Id", "Gender", "Model", "Size", "Thickness", "Type" },
                values: new object[,]
                {
                    { 13, "Herre", "Definition", "XS", "3 mm", "Våddragt" },
                    { 14, "Herre", "Definition", "S", "3 mm", "Våddragt" },
                    { 15, "Herre", "Definition", "M", "3 mm", "Våddragt" },
                    { 16, "Herre", "Definition", "L", "3 mm", "Våddragt" },
                    { 17, "Herre", "Definition", "XL", "3 mm", "Våddragt" },
                    { 18, "Herre", "Definition", "XS", "5 mm", "Våddragt" },
                    { 19, "Herre", "Definition", "S", "5 mm", "Våddragt" },
                    { 20, "Herre", "Definition", "M", "5 mm", "Våddragt" },
                    { 21, "Herre", "Definition", "L", "5 mm", "Våddragt" },
                    { 22, "Herre", "Definition", "XL", "5 mm", "Våddragt" },
                    { 23, "Herre", "Definition", "XS", "7 mm", "Våddragt" },
                    { 24, "Herre", "Definition", "S", "7 mm", "Våddragt" },
                    { 25, "Herre", "Definition", "M", "7 mm", "Våddragt" },
                    { 26, "Herre", "Definition", "L", "7 mm", "Våddragt" },
                    { 27, "Herre", "Definition", "XL", "7 mm", "Våddragt" },
                    { 28, "Dame", "Definition", "XS", "3 mm", "Våddragt" },
                    { 29, "Dame", "Definition", "S", "3 mm", "Våddragt" },
                    { 30, "Dame", "Definition", "M", "3 mm", "Våddragt" },
                    { 31, "Dame", "Definition", "L", "3 mm", "Våddragt" },
                    { 32, "Dame", "Definition", "XL", "3 mm", "Våddragt" },
                    { 33, "Dame", "Definition", "XS", "5 mm", "Våddragt" },
                    { 34, "Dame", "Definition", "S", "5 mm", "Våddragt" },
                    { 35, "Dame", "Definition", "M", "5 mm", "Våddragt" },
                    { 36, "Dame", "Definition", "L", "5 mm", "Våddragt" },
                    { 37, "Dame", "Definition", "XL", "5 mm", "Våddragt" },
                    { 38, "Dame", "Definition", "XS", "7 mm", "Våddragt" },
                    { 39, "Dame", "Definition", "S", "7 mm", "Våddragt" },
                    { 40, "Dame", "Definition", "M", "7 mm", "Våddragt" },
                    { 41, "Dame", "Definition", "L", "7 mm", "Våddragt" },
                    { 42, "Dame", "Definition", "XL", "7 mm", "Våddragt" },
                    { 43, "Herre", "W5", "XS", "3.5 mm", "Våddragt" },
                    { 44, "Herre", "W5", "S", "3.5 mm", "Våddragt" },
                    { 45, "Herre", "W5", "M", "3.5 mm", "Våddragt" },
                    { 46, "Herre", "W5", "L", "3.5 mm", "Våddragt" },
                    { 47, "Herre", "W5", "XL", "3.5 mm", "Våddragt" },
                    { 48, "Dame", "W5", "XS", "3.5 mm", "Våddragt" },
                    { 49, "Dame", "W5", "S", "3.5 mm", "Våddragt" },
                    { 50, "Dame", "W5", "M", "3.5 mm", "Våddragt" },
                    { 51, "Dame", "W5", "L", "3.5 mm", "Våddragt" },
                    { 52, "Dame", "W5", "XL", "3.5 mm", "Våddragt" },
                    { 53, "Herre", "Proteus", "XS", "5 mm", "Våddragt" },
                    { 54, "Herre", "Proteus", "S", "5 mm", "Våddragt" },
                    { 55, "Herre", "Proteus", "M", "5 mm", "Våddragt" },
                    { 56, "Herre", "Proteus", "L", "5 mm", "Våddragt" },
                    { 57, "Herre", "Proteus", "XL", "5 mm", "Våddragt" },
                    { 58, "Dame", "Proteus", "XS", "5 mm", "Våddragt" },
                    { 59, "Dame", "Proteus", "S", "5 mm", "Våddragt" },
                    { 60, "Dame", "Proteus", "M", "5 mm", "Våddragt" },
                    { 61, "Dame", "Proteus", "L", "5 mm", "Våddragt" },
                    { 62, "Dame", "Proteus", "XL", "5 mm", "Våddragt" },
                    { 63, "Herre", "Exodry 4.0", "XS", "N/A", "Tørdragt" },
                    { 64, "Herre", "Exodry 4.0", "S", "N/A", "Tørdragt" },
                    { 65, "Herre", "Exodry 4.0", "M", "N/A", "Tørdragt" },
                    { 66, "Herre", "Exodry 4.0", "L", "N/A", "Tørdragt" },
                    { 67, "Herre", "Exodry 4.0", "XL", "N/A", "Tørdragt" },
                    { 68, "Dame", "Exodry 4.0", "XS", "N/A", "Tørdragt" },
                    { 69, "Dame", "Exodry 4.0", "S", "N/A", "Tørdragt" },
                    { 70, "Dame", "Exodry 4.0", "M", "N/A", "Tørdragt" },
                    { 71, "Dame", "Exodry 4.0", "L", "N/A", "Tørdragt" },
                    { 72, "Dame", "Exodry 4.0", "XL", "N/A", "Tørdragt" },
                    { 73, "Herre", "D7 Evo", "XS", "N/A", "Tørdragt" },
                    { 74, "Herre", "D7 Evo", "S", "N/A", "Tørdragt" },
                    { 75, "Herre", "D7 Evo", "M", "N/A", "Tørdragt" },
                    { 76, "Herre", "D7 Evo", "L", "N/A", "Tørdragt" },
                    { 77, "Herre", "D7 Evo", "XL", "N/A", "Tørdragt" },
                    { 78, "Dame", "D7 Evo", "XS", "N/A", "Tørdragt" },
                    { 79, "Dame", "D7 Evo", "S", "N/A", "Tørdragt" },
                    { 80, "Dame", "D7 Evo", "M", "N/A", "Tørdragt" },
                    { 81, "Dame", "D7 Evo", "L", "N/A", "Tørdragt" },
                    { 82, "Dame", "D7 Evo", "XL", "N/A", "Tørdragt" },
                    { 83, "Herre", "E.Lite Plus", "XS", "N/A", "Tørdragt" },
                    { 84, "Herre", "E.Lite Plus", "S", "N/A", "Tørdragt" },
                    { 85, "Herre", "E.Lite Plus", "M", "N/A", "Tørdragt" },
                    { 86, "Herre", "E.Lite Plus", "L", "N/A", "Tørdragt" },
                    { 87, "Herre", "E.Lite Plus", "XL", "N/A", "Tørdragt" },
                    { 88, "Dame", "E.Lite Plus", "XS", "N/A", "Tørdragt" },
                    { 89, "Dame", "E.Lite Plus", "S", "N/A", "Tørdragt" },
                    { 90, "Dame", "E.Lite Plus", "M", "N/A", "Tørdragt" },
                    { 91, "Dame", "E.Lite Plus", "L", "N/A", "Tørdragt" },
                    { 92, "Dame", "E.Lite Plus", "XL", "N/A", "Tørdragt" }
                });

            migrationBuilder.InsertData(
                table: "Tanks",
                columns: new[] { "Id", "Volume" },
                values: new object[,]
                {
                    { 93, 5 },
                    { 94, 10 },
                    { 95, 12 },
                    { 96, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "Fins");

            migrationBuilder.DropTable(
                name: "Masks");

            migrationBuilder.DropTable(
                name: "Regulators");

            migrationBuilder.DropTable(
                name: "Suits");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
