using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityInfo.Api.Migrations
{
    /// <inheritdoc />
    public partial class newSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterests_Cities_cityId",
                table: "PointOfInterests");

            migrationBuilder.DropColumn(
                name: "CiityId",
                table: "PointOfInterests");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "PointOfInterests",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_PointOfInterests_cityId",
                table: "PointOfInterests",
                newName: "IX_PointOfInterests_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PointOfInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Algiers" },
                    { 2, null, "New York" },
                    { 3, null, "Paris" },
                    { 4, null, "Antwerp" }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterests",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, " best centra park ever:) ", "Central Park" },
                    { 2, 1, " best State building", "Empire State building" },
                    { 3, 2, "Algeria", "Notre dame de Paris" },
                    { 4, 2, "Makame", "Makame Chahid" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterests_Cities_CityId",
                table: "PointOfInterests",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterests_Cities_CityId",
                table: "PointOfInterests");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "PointOfInterests",
                newName: "cityId");

            migrationBuilder.RenameIndex(
                name: "IX_PointOfInterests_CityId",
                table: "PointOfInterests",
                newName: "IX_PointOfInterests_cityId");

            migrationBuilder.AlterColumn<int>(
                name: "cityId",
                table: "PointOfInterests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CiityId",
                table: "PointOfInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterests_Cities_cityId",
                table: "PointOfInterests",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
