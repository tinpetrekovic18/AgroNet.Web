using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroNet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MjestoModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Mjesta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Mjesta");
        }
    }
}
