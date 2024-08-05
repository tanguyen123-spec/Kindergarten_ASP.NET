using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateChiphibandaucolumonHocvientable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chiphibandau",
                table: "Hocvien",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Hocvien SET Chiphibandau = 0"); // Tùy chọn: Cung cấp giá trị mặc định cho các hàng đã tồn tại
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chiphibandau",
                table: "Hocvien");
        }
    }
}
