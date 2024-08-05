using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateHoatdongchinhTable : Migration
    {
       
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "Hoatdongchinh",
                    columns: table => new
                    {
                        MaHoatdongchinh = table.Column<string>(maxLength: 10, nullable: false),
                        Mahoatdong = table.Column<string>(maxLength: 10, nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Hoatdongchinh", x => x.MaHoatdongchinh);
                        // Add foreign key constraint if needed
                        // table.ForeignKey("FK_Hoatdongchinh_Hoatdong_Mahoatdong", x => x.Mahoatdong, "Hoatdong", "Mahoatdong", onDelete: ReferentialAction.Cascade);
                    });

                // Add any additional configuration or data seeding if needed

            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "Hoatdongchinh");
            }
        }
    }
