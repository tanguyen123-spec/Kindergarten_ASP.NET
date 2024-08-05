using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateChiphiphuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chiphiphu",
                columns: table => new
                {
                    Machiphiphu = table.Column<string>(type: "varchar(10)", nullable: false),
                       
                    Mahoatdong = table.Column<string>(type: "varchar(10)", nullable: false),
                       
                    Child_resume_id = table.Column<string>(type: "varchar(10)", nullable: false),
                        
                    Thang_namhoc = table.Column<string>(type: "varchar(10)", nullable: false),
                       
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chiphiphu", x => x.Machiphiphu);
                    table.ForeignKey("FK_Chiphiphu_Hoatdong_Mahoatdong", x => x.Mahoatdong, "Hoatdong", "Mahoatdong");
                    table.ForeignKey("FK_Chiphiphu_Hocvien_Child_resume_id", x => x.Child_resume_id, "Hocvien", "Child_resume_id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chiphiphu");
        }
    }
}
