using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class RemoveClassTypeIdToHocvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "ClassTypeId",
           table: "Hocvien");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
           name: "ClassTypeId",
           table: "Hocvien",
           type: "nvarchar(max)",
           nullable: true,
           defaultValue: 0);
        }
    }
    }

