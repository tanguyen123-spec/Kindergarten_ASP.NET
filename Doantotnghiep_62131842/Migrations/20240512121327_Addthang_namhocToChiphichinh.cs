using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class Addthang_namhocToChiphichinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "thang_namhoc",
                table: "Chiphichinh",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "thang_namhoc",
                table: "Chiphichinh");
        }
    }
}
