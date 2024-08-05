using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class Creatthang_namhocColumlumnTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
         name: "thang_namhoc",
         table: "Bienlai",
         "varchar(10)",
         nullable: true);
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
         name: "thang_namhoc",
         table: "Bienlai");
        }
    }
}
