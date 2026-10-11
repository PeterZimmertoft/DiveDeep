using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepWebApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Packages",
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
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
                name: "BookingProducts",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingProducts", x => new { x.BookingId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BookingProducts_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
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
                        name: "FK_PackageProducts_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProducts_Products_ProductId",
                        column: x => x.ProductId,
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "seed-admin-role", "seed-admin-role-v1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "seed-admin-user", 0, "seed-admin-user-v1", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGQ6yjNdMhGgwFxgREzQh5mclL2YGASMrLAtbColyu1JpaFmffKLycMIgkyghLV3DQ==", null, false, "seed-admin-security-v1", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Stabile og komfortable BCD’er, der giver sikker opdriftskontrol og god pasform. Velegnet til både nye og erfarne dykkere, uanset om du dykker i Danmark eller på rejser.", new byte[0], "BCD" },
                    { 2, "Våddragter og tørdragter i høj kvalitet, der giver optimal varme, komfort og bevægelsesfrihed. Perfekt til både koldt og varmt vand, og til dykkere på alle niveauer.", new byte[0], "Dykkerdragter" },
                    { 3, "Robuste og driftssikre dykkerflasker i flere størrelser. Giver den rette balance mellem luftmængde og vægt, så du kan dykke sikkert og komfortabelt.", new byte[0], "Tanke" },
                    { 4, "Pålidelige regulatorsæt med stabil luftlevering og høj åndingskomfort. Designet til sikker og behagelig dykning i både koldt og varmt vand.", new byte[0], "Regulatorsæt" },
                    { 5, "Komfortable masker med klart udsyn og god pasform samt snorkler til overfladesvømning. Ideelt til både snorkling og dykning.", new byte[0], "Maske/Snorkel" },
                    { 6, "Effektive og behagelige finner, der giver stærk fremdrift og god kontrol under vand. Passer til både rekreative og mere krævende dyk.", new byte[0], "Finner" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Denne all‑around dykkerpakke er skabt til dig, der vil opleve havet med udstyr, der føles naturligt og trygt fra første sekund under overfladen. Scubapro‑kvaliteten går igen i hele sættet og giver en harmonisk pasform og stabil oplevelse, uanset hvor du dykker. Kombinationen af 5 mm dragt, Hydros Pro BCD, 12 L tank og MK25EVO/S600 regulatorsættet er en gennemprøvet opsætning, der leverer både komfort og sikkerhed. Masken og finnerne er valgt for deres fleksibilitet og lette håndtering, så både nye og erfarne dykkere kan glide ubesværet gennem vandet. En stærk, velafbalanceret pakke til dig, der vil dykke dybt — og dykke godt.", new byte[0], "Komplet dykkersæt" },
                    { 2, "Denne pakke er skabt til dig, der vil udforske havet med udstyr, der føles let, behageligt og intuitivt fra første øjeblik. Masken og snorklen giver høj komfort og en pasform, der gør det nemt at fokusere på oplevelsen under overfladen, mens finnerne leverer en jævn, kraftfuld fremdrift, uanset om du snorkler langs kysten eller dykker ned i det blå. Hele sættet er let, robust og nemt at transportere, så du kan tage det med på både små og store eventyr. Du får premium kvalitet, der løfter oplevelsen — uden at prisen løber løbsk.", new byte[0], "Komplet snorkelsæt" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "seed-admin-role", "seed-admin-user" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Scubapro", 1, "Let og stabil BCD med god komfort. Perfekt til rekreativ dykning og nem at håndtere for alle niveauer.", new byte[0], "Navigator Lite BCD", 125.0, 5 },
                    { 2, "Scubapro", 1, "Let og stabil BCD med god komfort. Perfekt til rekreativ dykning og nem at håndtere for alle niveauer.", new byte[0], "Navigator Lite BCD", 125.0, 5 },
                    { 3, "Scubapro", 1, "Let og stabil BCD med god komfort. Perfekt til rekreativ dykning og nem at håndtere for alle niveauer.", new byte[0], "Navigator Lite BCD", 125.0, 5 },
                    { 4, "Scubapro", 1, "Komfortabel og justerbar BCD med god opdriftskontrol. Et solidt valg til de fleste dykkere.", new byte[0], "BCD Glide", 140.0, 5 },
                    { 5, "Scubapro", 1, "Komfortabel og justerbar BCD med god opdriftskontrol. Et solidt valg til de fleste dykkere.", new byte[0], "BCD Glide", 140.0, 5 },
                    { 6, "Scubapro", 1, "Komfortabel og justerbar BCD med god opdriftskontrol. Et solidt valg til de fleste dykkere.", new byte[0], "BCD Glide", 140.0, 5 },
                    { 7, "Scubapro", 1, "Modulær, stabil og meget komfortabel BCD. Tørrer hurtigt og fungerer i både koldt og varmt vand.", new byte[0], "BCD Hydros Pro", 200.0, 5 },
                    { 8, "Scubapro", 1, "Modulær, stabil og meget komfortabel BCD. Tørrer hurtigt og fungerer i både koldt og varmt vand.", new byte[0], "BCD Hydros Pro", 200.0, 5 },
                    { 9, "Scubapro", 1, "Modulær, stabil og meget komfortabel BCD. Tørrer hurtigt og fungerer i både koldt og varmt vand.", new byte[0], "BCD Hydros Pro", 200.0, 5 },
                    { 10, "Seac", 1, "Fleksibel og robust BCD med modulopbygning. Ideel til dykkere, der ønsker tilpasning og stabilitet.", new byte[0], "BCD Modular", 145.0, 5 },
                    { 11, "Seac", 1, "Fleksibel og robust BCD med modulopbygning. Ideel til dykkere, der ønsker tilpasning og stabilitet.", new byte[0], "BCD Modular", 145.0, 5 },
                    { 12, "Seac", 1, "Fleksibel og robust BCD med modulopbygning. Ideel til dykkere, der ønsker tilpasning og stabilitet.", new byte[0], "BCD Modular", 145.0, 5 },
                    { 13, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 14, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 15, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 16, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 17, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 18, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 19, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 20, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 21, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 22, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 23, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 24, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 25, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 26, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 27, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 28, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 29, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 30, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 31, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 32, "Scubapro", 2, "Let og fleksibel våddragt til varmere vand. Giver god bevægelsesfrihed og komfort.", new byte[0], "Definition", 100.0, 5 },
                    { 33, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 34, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 35, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 36, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 37, "Scubapro", 2, "All‑around våddragt med god varme og pasform. Perfekt til danske forhold og rejser.", new byte[0], "Definition", 100.0, 5 },
                    { 38, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 39, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 40, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 41, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 42, "Scubapro", 2, "Ekstra varm våddragt til koldere vand. Giver god isolering og tæt pasform.", new byte[0], "Definition", 100.0, 5 },
                    { 43, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 44, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 45, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 46, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 47, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 48, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 49, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 50, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 51, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 52, "Waterproof", 2, "Komfortabel og slidstærk våddragt med høj kvalitet. Ideel til tempereret vand.", new byte[0], "W5", 100.0, 5 },
                    { 53, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 54, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 55, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk", new byte[0], "Proteus", 120.0, 5 },
                    { 56, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk", new byte[0], "Proteus", 120.0, 5 },
                    { 57, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 58, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 59, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 60, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 61, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 62, "Fourth Element", 2, "Premium våddragt med fremragende varme og tæt pasform. Perfekt til krævende dyk.", new byte[0], "Proteus", 120.0, 5 },
                    { 63, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 64, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 65, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 66, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 67, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 68, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 69, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 70, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 71, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 72, "Scubapro", 2, "Let og pålidelig tørdragt med god bevægelsesfrihed. Holder dig tør i koldere vand.", new byte[0], "Exodry 4.0", 300.0, 5 },
                    { 73, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 74, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 75, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere", new byte[0], "D7 Evo", 320.0, 5 },
                    { 76, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere", new byte[0], "D7 Evo", 320.0, 5 },
                    { 77, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 78, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 79, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 80, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere", new byte[0], "D7 Evo", 320.0, 5 },
                    { 81, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 82, "Waterproof", 2, "Robust og avanceret tørdragt med høj komfort. Designet til seriøse dykkere.", new byte[0], "D7 Evo", 320.0, 5 },
                    { 83, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 84, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 85, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 86, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 87, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 88, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 89, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 90, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 91, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 92, "Santi", 2, "Topklasse tørdragt med maksimal holdbarhed og komfort. Skabt til tekniske og kolde dyk.", new byte[0], "E.Lite Plus", 350.0, 5 },
                    { 93, "Scubapro", 3, "Let og kompakt tank til korte dyk eller træning. Nem at håndtere og transportere.", new byte[0], "5L tank", 150.0, 5 },
                    { 94, "Scubapro", 3, "God balance mellem vægt og luftmængde. Velegnet til rekreative dyk.", new byte[0], "10L tank", 160.0, 5 },
                    { 95, "Scubapro", 3, "Standard tank til de fleste dykkere. Stabil, alsidig og passer til alle setups.", new byte[0], "12L tank", 170.0, 5 },
                    { 96, "Scubapro", 3, "Ekstra luft til længere dyk. Perfekt til dykkere med højt luftforbrug.", new byte[0], "15L tank", 180.0, 5 },
                    { 97, "Scubapro", 4, "Højtydende regulatorsæt med fremragende åndingskomfort og stabilitet.", new byte[0], "MK25EVO / S600", 125.0, 5 },
                    { 98, "Scubapro", 4, "Driftsikkert og kompakt regulatorsæt. Ideelt til rekreativ dykning.", new byte[0], "MK17EVO / C370", 100.0, 5 },
                    { 99, "Scubapro", 4, "Premium regulatorsæt med topydelse og letvægtsdesign. Perfekt til krævende dyk.", new byte[0], "MK25EVO BT / A700 Carbon BT", 150.0, 5 },
                    { 100, "Scubapro", 5, "Let og minimalistisk maske med bredt udsyn. Sidder komfortabelt og stabilt.", new byte[0], "Ghost", 50.0, 5 },
                    { 101, "Scubapro", 5, "Premium maske med fantastisk pasform og klar optik. Perfekt til alle dykkere.", new byte[0], "D-Mask", 60.0, 5 },
                    { 102, "Scubapro", 5, "Kompakt maske med god pasform til mindre ansigter. Giver klart udsyn.", new byte[0], "Spectra Mini", 50.0, 5 },
                    { 103, "Scubapro", 5, "Maske med ekstra bredt synsfelt. Komfortabel og ideel til rekreative dyk.", new byte[0], "Crystal VU", 75.0, 5 },
                    { 104, "Fourth Element", 5, "Maske med kontrastforstærkende linse. Giver skarpt udsyn under vand.", new byte[0], "Scout Kontrast", 75.0, 5 },
                    { 105, "Fourth Element", 5, "Maske med forbedret farvegengivelse. Komfortabel og alsidig.", new byte[0], "Scout Enhance", 75.0, 5 },
                    { 106, "Tusa", 5, "Komfortabel maske med bredt udsyn og god pasform. Velegnet til alle niveauer.", new byte[0], "Element", 75.0, 5 },
                    { 107, "Scubapro", 6, "Klassisk, kraftfuld finne med solid fremdrift. Perfekt til præcis kontrol.", new byte[0], "Jet Fin", 50.0, 5 },
                    { 108, "Scubapro", 6, "Klassisk, kraftfuld finne med solid fremdrift. Perfekt til præcis kontrol.", new byte[0], "Jet Fin", 50.0, 5 },
                    { 109, "Scubapro", 6, "Klassisk, kraftfuld finne med solid fremdrift. Perfekt til præcis kontrol.", new byte[0], "Jet Fin", 50.0, 5 },
                    { 110, "Scubapro", 6, "Klassisk, kraftfuld finne med solid fremdrift. Perfekt til præcis kontrol.", new byte[0], "Jet Fin", 50.0, 5 },
                    { 111, "Scubapro", 6, "Klassisk, kraftfuld finne med solid fremdrift. Perfekt til præcis kontrol.", new byte[0], "Jet Fin", 50.0, 5 },
                    { 112, "Scubapro", 6, "Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.", new byte[0], "GO Travel", 50.0, 5 },
                    { 113, "Scubapro", 6, "Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.", new byte[0], "GO Travel", 50.0, 5 },
                    { 114, "Scubapro", 6, "Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkLet og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.ere.", new byte[0], "GO Travel", 50.0, 5 },
                    { 115, "Scubapro", 6, "Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.", new byte[0], "GO Travel", 50.0, 5 },
                    { 116, "Scubapro", 6, "Let og rejsevenlig finne med god effektivitet. Ideel til feriedykkere.", new byte[0], "GO Travel", 50.0, 5 },
                    { 117, "Scubapro", 6, "Moderne finne med stærk fremdrift og fleksibilitet. Komfortabel og effektiv.", new byte[0], "Seawing Supernova", 60.0, 5 },
                    { 118, "Scubapro", 6, "Moderne finne med stærk fremdrift og fleksibilitet. Komfortabel og effektiv.", new byte[0], "Seawing Supernova", 60.0, 5 },
                    { 119, "Scubapro", 6, "Moderne finne med stærk fremdrift og fleksibilitet. Komfortabel og effektiv.", new byte[0], "Seawing Supernova", 60.0, 5 },
                    { 120, "Scubapro", 6, "Moderne finne med stærk fremdrift og fleksibilitet. Komfortabel og effektiv.", new byte[0], "Seawing Supernova", 60.0, 5 },
                    { 121, "Scubapro", 6, "Moderne finne med stærk fremdrift og fleksibilitet. Komfortabel og effektiv.", new byte[0], "Seawing Supernova", 60.0, 5 },
                    { 122, "Seac", 6, "Let og stabil finne med god ydeevne. Velegnet til rekreative dyk.", new byte[0], "Propulsion", 50.0, 5 },
                    { 123, "Seac", 6, "Let og stabil finne med god ydeevne. Velegnet til rekreative dyk.", new byte[0], "Propulsion", 50.0, 5 },
                    { 124, "Seac", 6, "Let og stabil finne med god ydeevne. Velegnet til rekreative dyk.", new byte[0], "Propulsion", 50.0, 5 },
                    { 125, "Seac", 6, "Let og stabil finne med god ydeevne. Velegnet til rekreative dyk.", new byte[0], "Propulsion", 50.0, 5 },
                    { 126, "Seac", 6, "Let og stabil finne med god ydeevne. Velegnet til rekreative dyk.", new byte[0], "Propulsion", 50.0, 5 },
                    { 127, "Seac", 6, "Komfortabel finne med jævn fremdrift. God til både nybegyndere og øvede.", new byte[0], "ALA", 50.0, 5 },
                    { 128, "Seac", 6, "Komfortabel finne med jævn fremdrift. God til både nybegyndere og øvede.", new byte[0], "ALA", 50.0, 5 },
                    { 129, "Seac", 6, "Komfortabel finne med jævn fremdrift. God til både nybegyndere og øvede.", new byte[0], "ALA", 50.0, 5 },
                    { 130, "Seac", 6, "Komfortabel finne med jævn fremdrift. God til både nybegyndere og øvede.", new byte[0], "ALA", 50.0, 5 },
                    { 131, "Seac", 6, "Komfortabel finne med jævn fremdrift. God til både nybegyndere og øvede.", new byte[0], "ALA", 50.0, 5 },
                    { 132, "Fourth Element", 6, "Robust finne med kraftig fremdrift. Ideel til tekniske og krævende dyk.", new byte[0], "Tech", 75.0, 5 },
                    { 133, "Fourth Element", 6, "Robust finne med kraftig fremdrift. Ideel til tekniske og krævende dyk.", new byte[0], "Tech", 75.0, 5 },
                    { 134, "Fourth Element", 6, "Robust finne med kraftig fremdrift. Ideel til tekniske og krævende dyk.", new byte[0], "Tech", 75.0, 5 },
                    { 135, "Fourth Element", 6, "Robust finne med kraftig fremdrift. Ideel til tekniske og krævende dyk.", new byte[0], "Tech", 75.0, 5 },
                    { 136, "Fourth Element", 6, "Robust finne med kraftig fremdrift. Ideel til tekniske og krævende dyk.", new byte[0], "Tech", 75.0, 5 },
                    { 137, "Fourth Element", 6, "Effektiv og komfortabel finne til rekreative dyk. Giver god kontrol og fremdrift.", new byte[0], "Rec Fin", 80.0, 5 },
                    { 138, "Fourth Element", 6, "Effektiv og komfortabel finne til rekreative dyk. Giver god kontrol og fremdrift.", new byte[0], "Rec Fin", 80.0, 5 },
                    { 139, "Fourth Element", 6, "Effektiv og komfortabel finne til rekreative dyk. Giver god kontrol og fremdrift.", new byte[0], "Rec Fin", 80.0, 5 },
                    { 140, "Fourth Element", 6, "Effektiv og komfortabel finne til rekreative dyk. Giver god kontrol og fremdrift.", new byte[0], "Rec Fin", 80.0, 5 },
                    { 141, "Fourth Element", 6, "Effektiv og komfortabel finne til rekreative dyk. Giver god kontrol og fremdrift.", new byte[0], "Rec Fin", 80.0, 5 }
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
                    { 136, "Tech", "XL" },
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingProducts_ProductId",
                table: "BookingProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PackageId",
                table: "CartItems",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProducts_ProductId",
                table: "PackageProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "BookingProducts");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Fins");

            migrationBuilder.DropTable(
                name: "Masks");

            migrationBuilder.DropTable(
                name: "PackageProducts");

            migrationBuilder.DropTable(
                name: "Regulators");

            migrationBuilder.DropTable(
                name: "Suits");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
