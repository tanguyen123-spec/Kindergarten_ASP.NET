using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateBienlaiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
       name: "Bienlai",
       columns: table => new
       {
           Mabienlai = table.Column<string>(type: "varchar(10)", nullable: false),
           ChildResumeId = table.Column<string>(type: "varchar(10)", nullable: false),
           tongchiphiphaitra = table.Column<int>(nullable: false),
           trangthai = table.Column<bool>(nullable: false)
       },
       constraints: table =>
       {
           table.PrimaryKey("PK_Bienlai", x => x.Mabienlai);
           table.ForeignKey("FK_Bienlai_Hocvien", x => x.ChildResumeId, "Hocvien", "Child_resume_id");
       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
