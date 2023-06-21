using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Number = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.HotelId, x.Number });
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1L, 55.167137f, 61.379574f },
                    { 2L, 55.16725f, 61.395924f },
                    { 3L, 55.161903f, 61.43048f }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "HotelId", "Number", "Class", "Floor", "ImageUrl", "Price", "State" },
                values: new object[,]
                {
                    { 1L, 1, "Luxe", 1, "https://loremflickr.com/320/240?lock=1229780929", 9999m, "Clean" },
                    { 1L, 2, "Default", 1, "https://loremflickr.com/320/240?lock=923646772", 301m, "Clean" },
                    { 1L, 3, "VIP", 1, "https://loremflickr.com/320/240?lock=1356708602", 1m, "Clean" },
                    { 2L, 100, "Default", 1, "https://loremflickr.com/320/240?lock=308339214", 301m, "Clean" },
                    { 2L, 101, "Luxe", 1, "https://loremflickr.com/320/240?lock=943028256", 100m, "Clean" },
                    { 2L, 200, "Default", 2, "https://loremflickr.com/320/240?lock=1640880358", 301m, "Clean" },
                    { 2L, 201, "Default", 2, "https://loremflickr.com/320/240?lock=812584830", 301m, "Clean" },
                    { 3L, 10, "Luxe", 1, "https://loremflickr.com/320/240?lock=446532168", 1111m, "Clean" },
                    { 3L, 11, "Default", 1, "https://loremflickr.com/320/240?lock=1550699072", 301m, "Clean" },
                    { 3L, 12, "Default", 1, "https://loremflickr.com/320/240?lock=1826706350", 301m, "Clean" },
                    { 3L, 20, "VIP", 2, "https://loremflickr.com/320/240?lock=511833658", 675656m, "Clean" },
                    { 3L, 21, "VIP", 2, "https://loremflickr.com/320/240?lock=804161671", 19222m, "Clean" },
                    { 3L, 22, "Luxe", 2, "https://loremflickr.com/320/240?lock=2005243139", 1m, "Clean" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Latitude_Longitude",
                table: "Hotel",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
