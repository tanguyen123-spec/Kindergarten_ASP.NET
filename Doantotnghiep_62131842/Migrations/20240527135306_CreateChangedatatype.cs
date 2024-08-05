using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateChangedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tpdduongL",
                table: "Lunchdataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FoodLunch",
                table: "Lunchdataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongDS",
                table: "Desertdataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FoodDS",
                table: "Desertdataset",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongBF",
                table: "BFdataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FoodBF",
                table: "BFdataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongAF",
                table: "AFnoondataset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FoodAF",
                table: "AFnoondataset",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "tpdduongL",
               table: "Lunchdataset",
               type: "text",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FoodLunch",
                table: "Lunchdataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongDS",
                table: "Desertdataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FoodDS",
                table: "Desertdataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongBF",
                table: "BFdataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FoodBF",
                table: "BFdataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tpdduongAF",
                table: "AFnoondataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FoodAF",
                table: "AFnoondataset",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
