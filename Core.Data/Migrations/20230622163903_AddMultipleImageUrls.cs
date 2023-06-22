using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Room");

            migrationBuilder.AddColumn<string[]>(
                name: "ImageUrls",
                table: "Room",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 1 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=189138406", "https://loremflickr.com/320/240?lock=27174788", "https://loremflickr.com/320/240?lock=1544873238" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 2 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=1851191940", "https://loremflickr.com/320/240?lock=399730367", "https://loremflickr.com/320/240?lock=573170156", "https://loremflickr.com/320/240?lock=1132734020", "https://loremflickr.com/320/240?lock=790063001" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1L, 3 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=1639224297" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 100 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=1380156770", "https://loremflickr.com/320/240?lock=487483428", "https://loremflickr.com/320/240?lock=2034697242", "https://loremflickr.com/320/240?lock=64901873" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 101 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=836161306" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 200 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=468905345" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2L, 201 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=122338698", "https://loremflickr.com/320/240?lock=1515236549", "https://loremflickr.com/320/240?lock=590212116", "https://loremflickr.com/320/240?lock=67448649", "https://loremflickr.com/320/240?lock=388649953" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 10 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=851616216" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 11 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=644412431", "https://loremflickr.com/320/240?lock=1373935383", "https://loremflickr.com/320/240?lock=1012521378", "https://loremflickr.com/320/240?lock=2054292510" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 12 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=1794507171" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 20 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=750884345" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 21 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=620724332", "https://loremflickr.com/320/240?lock=2087698577", "https://loremflickr.com/320/240?lock=2116665496", "https://loremflickr.com/320/240?lock=1233713347" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 3L, 22 },
                column: "ImageUrls",
                value: new[] { "https://loremflickr.com/320/240?lock=1792191646", "https://loremflickr.com/320/240?lock=499288552", "https://loremflickr.com/320/240?lock=381462456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
