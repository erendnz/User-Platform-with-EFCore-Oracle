using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErenDenizEF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMINLER",
                columns: table => new
                {
                    ADMIN_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ADMIN_ADI = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ADMIN_SOYADI = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    KULLANICI_ADI = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    SIFRE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMINLER", x => x.ADMIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "SANATCİLAR",
                columns: table => new
                {
                    SANATCI_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SANATCI_ADI = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANATCİLAR", x => x.SANATCI_ID);
                });

            migrationBuilder.CreateTable(
                name: "ALBUMLER",
                columns: table => new
                {
                    ALBUM_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ALBUM_ADI = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CIKIS_TARIHI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FIYAT = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    INDIRIM_ORANI = table.Column<double>(type: "BINARY_DOUBLE", nullable: false, defaultValue: 0.0),
                    ALBUM_DURUMU = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 1),
                    SANATCI_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALBUMLER", x => x.ALBUM_ID);
                    table.ForeignKey(
                        name: "FK_ALBUMLER_SANATCİLAR_SANATCI_ID",
                        column: x => x.SANATCI_ID,
                        principalTable: "SANATCİLAR",
                        principalColumn: "SANATCI_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ADMINLER",
                columns: new[] { "ADMIN_ID", "ADMIN_ADI", "KULLANICI_ADI", "SIFRE", "ADMIN_SOYADI" },
                values: new object[] { 1, "Eren", "erendnz", "B22F18A5A24EAA5E0A6673DDE1D64DC4C0A7595C4B263F947426736A59D1ED20", "Kilic" });

            migrationBuilder.InsertData(
                table: "SANATCİLAR",
                columns: new[] { "SANATCI_ID", "SANATCI_ADI" },
                values: new object[] { 1, "Pink Floyd" });

            migrationBuilder.InsertData(
                table: "SANATCİLAR",
                columns: new[] { "SANATCI_ID", "SANATCI_ADI" },
                values: new object[] { 2, "GunsNRoses" });

            migrationBuilder.InsertData(
                table: "ALBUMLER",
                columns: new[] { "ALBUM_ID", "ALBUM_ADI", "CIKIS_TARIHI", "FIYAT", "SANATCI_ID" },
                values: new object[] { 1, "The Wall", new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), 50.0, 1 });

            migrationBuilder.InsertData(
                table: "ALBUMLER",
                columns: new[] { "ALBUM_ID", "ALBUM_ADI", "CIKIS_TARIHI", "FIYAT", "SANATCI_ID" },
                values: new object[] { 2, "Use Your Illısıon-1", new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), 35.0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ALBUMLER_SANATCI_ID",
                table: "ALBUMLER",
                column: "SANATCI_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMINLER");

            migrationBuilder.DropTable(
                name: "ALBUMLER");

            migrationBuilder.DropTable(
                name: "SANATCİLAR");
        }
    }
}
