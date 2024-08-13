using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroNet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zupanije",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zagrebačka županija" },
                    { 2, "Krapinsko-zagorska županija" },
                    { 3, "Sisačko-moslavačka županija" },
                    { 4, "Karlovačka županija" },
                    { 5, "Varaždinska županija" },
                    { 6, "Koprivničko-križevačka županija" },
                    { 7, "Bjelovarsko-bilogorska županija" },
                    { 8, "Primorsko-goranska županija" },
                    { 9, "Ličko-senjska županija" },
                    { 10, "Virovitičko-podravska županija" },
                    { 11, "Požeško-slavonska županija" },
                    { 12, "Brodsko-posavska županija" },
                    { 13, "Zadarska županija" },
                    { 14, "Osječko-baranjska županija" },
                    { 15, "Šibensko-kninska županija" },
                    { 16, "Vukovarsko-srijemska županija" },
                    { 17, "Splitsko-dalmatinska županija" },
                    { 18, "Istarska županija" },
                    { 19, "Dubrovačko-neretvanska županija" },
                    { 20, "Međimurska županija" },
                    { 21, "Grad Zagreb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Zupanije",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
