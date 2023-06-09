using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1L, "Улица Труда, 179, Челябинск, 454080", "RadissonBlu" },
                    { 2L, "Улица Труда, 153, Челябинск, 454091", "Малахит" },
                    { 3L, "Проспект Ленина, 26А, Челябинск, 454007", "Гранд отель Видгоф" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "HotelId", "Number", "State" },
                values: new object[,]
                {
                    { 1L, 1, "Clean" },
                    { 1L, 2, "Clean" },
                    { 1L, 3, "Clean" },
                    { 2L, 100, "Clean" },
                    { 2L, 101, "Clean" },
                    { 2L, 200, "Clean" },
                    { 2L, 201, "Clean" },
                    { 3L, 10, "Clean" },
                    { 3L, 11, "Clean" },
                    { 3L, 12, "Clean" },
                    { 3L, 20, "Clean" },
                    { 3L, 21, "Clean" },
                    { 3L, 22, "Clean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 1 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 2 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 3 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 100 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 101 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 200 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 201 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 10 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 11 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 12 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 20 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 21 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 22 });

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
