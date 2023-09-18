using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAnnouncements.Migrations
{
    public partial class CreateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    EngineVolume = table.Column<int>(type: "int", nullable: false),
                    BanId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    GasId = table.Column<int>(type: "int", nullable: false),
                    GearBoxId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Bans_BanId",
                        column: x => x.BanId,
                        principalTable: "Bans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Gases_GasId",
                        column: x => x.GasId,
                        principalTable: "Gases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_GearBoxes_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bans",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Avtobus" },
                    { 2, "Dartqı" },
                    { 3, "Furqon" },
                    { 4, "Hetçbek" },
                    { 5, "Karvan" },
                    { 6, "Kabriolet" },
                    { 7, "Liftbek" },
                    { 8, "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 8, "Mavi" },
                    { 7, "Yaşıl" },
                    { 6, "Gümüşü" },
                    { 5, "Ağ" },
                    { 2, "Boz" },
                    { 3, "Yaş Asfalt" },
                    { 1, "Qara" },
                    { 4, "Qırmızı" }
                });

            migrationBuilder.InsertData(
                table: "Gases",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 5, "Hibrid" },
                    { 6, "Plug-in Hibrid" },
                    { 4, "Elektiro" },
                    { 2, "Dizel" },
                    { 1, "Benzin" },
                    { 3, "Qaz" }
                });

            migrationBuilder.InsertData(
                table: "GearBoxes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Mexaniki" },
                    { 2, "Avtomat" },
                    { 3, "Robotlaştırılmış" },
                    { 4, "Variator" }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 9, "Tesla" },
                    { 1, "Dodge" },
                    { 2, "Audi" },
                    { 3, "BMW" },
                    { 4, "Fiat" },
                    { 5, "Ford" },
                    { 6, "Ferrari" },
                    { 7, "Mercedes" },
                    { 8, "Toyota" },
                    { 10, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MarkId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Dart" },
                    { 28, 10, "Rabbit" },
                    { 27, 9, "Model X" },
                    { 26, 9, "Roadster" },
                    { 25, 9, "Cybertruck" },
                    { 24, 8, "Supra" },
                    { 23, 8, "Camry" },
                    { 22, 8, "Prius" },
                    { 21, 7, "CLK 240" },
                    { 20, 7, "AMG GT" },
                    { 19, 7, "190" },
                    { 18, 6, "Enzo" },
                    { 17, 6, "458 Spider" },
                    { 16, 6, "296 GTB" },
                    { 15, 5, "Tempo" },
                    { 14, 5, "Mustang" },
                    { 13, 5, "Focus" },
                    { 12, 4, "Croma" },
                    { 11, 4, "Coupe" },
                    { 10, 4, "Bravo" },
                    { 9, 3, "M5" },
                    { 8, 3, "M4" },
                    { 7, 3, "M3" },
                    { 6, 2, "A3" },
                    { 5, 2, "A2" },
                    { 4, 2, "A1" },
                    { 3, 1, "Durango" },
                    { 2, 1, "Dakota" },
                    { 29, 10, "Taos" },
                    { 30, 10, "Polo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_BanId",
                table: "Announcements",
                column: "BanId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ColorId",
                table: "Announcements",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_GasId",
                table: "Announcements",
                column: "GasId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_GearBoxId",
                table: "Announcements",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ModelId",
                table: "Announcements",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AnnouncementId",
                table: "Images",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_MarkId",
                table: "Models",
                column: "MarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Gases");

            migrationBuilder.DropTable(
                name: "GearBoxes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Marks");
        }
    }
}
