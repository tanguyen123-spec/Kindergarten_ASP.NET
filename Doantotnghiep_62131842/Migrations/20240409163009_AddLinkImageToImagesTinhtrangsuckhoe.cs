using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkImageToImagesTinhtrangsuckhoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
          name: "LinkUrl",
          table: "ImagesTinhtrangsuckhoe",
          nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chiphiphaithu");

            migrationBuilder.DropTable(
                name: "chitietgiaovien_lop");

            migrationBuilder.DropTable(
                name: "Danhmonantheongay");

            migrationBuilder.DropTable(
                name: "ImagesTinhtrangsuckhoe");

            migrationBuilder.DropTable(
                name: "Phieubengoan");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Suckhoedinhki");

            migrationBuilder.DropTable(
                name: "Tiethoc");

            migrationBuilder.DropTable(
                name: "Ykien");

            migrationBuilder.DropTable(
                name: "Phieudiemdanh");

            migrationBuilder.DropTable(
                name: "Hoatdong");

            migrationBuilder.DropTable(
                name: "DSThucDon");

            migrationBuilder.DropTable(
                name: "Tinhtrangsuckhoe");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Thoikhoabieu");

            migrationBuilder.DropTable(
                name: "Chude");

            migrationBuilder.DropTable(
                name: "Hocvien");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Giaovien");

            migrationBuilder.DropTable(
                name: "Donnhaphoc");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "Phuhuynh");

            migrationBuilder.DropTable(
                name: "Loaigiaovien");

            migrationBuilder.DropTable(
                name: "Loailop");
        }
    }
}
