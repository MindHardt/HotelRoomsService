using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomModifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomModifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomModifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomRoomModifier",
                columns: table => new
                {
                    RoomModifiersId = table.Column<long>(type: "bigint", nullable: false),
                    RoomsHotelId = table.Column<long>(type: "bigint", nullable: false),
                    RoomsNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRoomModifier", x => new { x.RoomModifiersId, x.RoomsHotelId, x.RoomsNumber });
                    table.ForeignKey(
                        name: "FK_RoomRoomModifier_RoomModifier_RoomModifiersId",
                        column: x => x.RoomModifiersId,
                        principalTable: "RoomModifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRoomModifier_Room_RoomsHotelId_RoomsNumber",
                        columns: x => new { x.RoomsHotelId, x.RoomsNumber },
                        principalTable: "Room",
                        principalColumns: new[] { "HotelId", "Number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 1 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1405329359");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 2 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1844725699");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 3 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=661824766");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 100 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1522061971");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 101 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=379889922");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 200 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=2112474485");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 201 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1959292877");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 10 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=389323284");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 11 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=387753694");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 12 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=443725542");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 20 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1517424132");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 21 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=87453138");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 22 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1819357836");

            migrationBuilder.InsertData(
                table: "RoomModifier",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Двуспальная кровать" },
                    { 2L, "Односпальная кровать" },
                    { 3L, "Питание включено" },
                    { 4L, "Питание не включено" },
                    { 5L, "Сейф есть" },
                    { 6L, "Сейфа нет" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomRoomModifier_RoomsHotelId_RoomsNumber",
                table: "RoomRoomModifier",
                columns: new[] { "RoomsHotelId", "RoomsNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomRoomModifier");

            migrationBuilder.DropTable(
                name: "RoomModifier");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 1 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1229780929");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 2 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=923646772");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 3 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1356708602");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 100 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=308339214");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 101 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=943028256");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 200 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1640880358");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 201 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=812584830");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 10 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=446532168");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 11 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1550699072");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 12 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=1826706350");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 20 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=511833658");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 21 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=804161671");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 22 },
                column: "ImageUrl",
                value: "https://loremflickr.com/320/240?lock=2005243139");
        }
    }
}
