using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class AddClassTypeIdToHocvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "classtypeId",
            table: "Hocvien",
            type: "varchar(10)",
            nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
