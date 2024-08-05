using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doantotnghiep_62131842.Migrations
{
    /// <inheritdoc />
    public partial class CreateChiphichinhTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chiphiphaithu");
            migrationBuilder.CreateTable(
            name: "Chiphichinh",
            columns: table => new
            {
                Machiphichinh = table.Column<string>(type: "varchar(10)", nullable: false),
                Mahoatdong = table.Column<string>(type: "varchar(10)", nullable: false),
                Tongsobuoidiemdanh = table.Column<int>(nullable: false),
                Tongchiphi = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Chiphichinh", x => x.Machiphichinh);
                table.ForeignKey("FK_Chiphichinh_Hoatdong_mahoatdong", x => x.Mahoatdong, "Hoatdong", "mahoatdong");
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chiphiphaithu",
                columns: table => new
                {
                    receivable_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Child_resume_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Diemdanh_id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Mahoatdong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ngaydong = table.Column<DateTime>(type: "datetime", nullable: true),
                    phuphikhac = table.Column<int>(type: "int", nullable: true),
                    phuphikhac_note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    total_cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chiphiph__F9BBD07726FB77E0", x => x.receivable_ID);
                    table.ForeignKey(
                        name: "FK__Chiphipha__Child__6C190EBB",
                        column: x => x.Child_resume_ID,
                        principalTable: "Hocvien",
                        principalColumn: "Child_resume_ID");
                    table.ForeignKey(
                        name: "FK__Chiphipha__Diemd__6D0D32F4",
                        column: x => x.Diemdanh_id,
                        principalTable: "Phieudiemdanh",
                        principalColumn: "Diemdanh_id");
                    table.ForeignKey(
                        name: "FK__Chiphipha__Mahoa__6B24EA82",
                        column: x => x.Mahoatdong,
                        principalTable: "Hoatdong",
                        principalColumn: "Mahoatdong");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chiphiphaithu_Child_resume_ID",
                table: "Chiphiphaithu",
                column: "Child_resume_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Chiphiphaithu_Diemdanh_id",
                table: "Chiphiphaithu",
                column: "Diemdanh_id");

            migrationBuilder.CreateIndex(
                name: "IX_Chiphiphaithu_Mahoatdong",
                table: "Chiphiphaithu",
                column: "Mahoatdong");
        }
    }
}
