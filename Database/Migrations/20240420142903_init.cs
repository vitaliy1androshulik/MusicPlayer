using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountOfTracks = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Autors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Autors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayListTrack",
                columns: table => new
                {
                    PlayListsId = table.Column<int>(type: "int", nullable: false),
                    TracksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListTrack", x => new { x.PlayListsId, x.TracksId });
                    table.ForeignKey(
                        name: "FK_PlayListTrack_PlayLists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListTrack_Tracks_TracksId",
                        column: x => x.TracksId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autors",
                columns: new[] { "Id", "LastName", "Name", "Nationality", "SurName" },
                values: new object[,]
                {
                    { 1, "Anatolyevich", "Oleg", "Ukraine", "Vinnik" },
                    { 2, "Rodriguez", "Luis", "Puerto Rico", "Fonsi" },
                    { 3, "Bohlen", "Dieter", "Germany", "Gunter" }
                });

            migrationBuilder.InsertData(
                table: "PlayLists",
                columns: new[] { "Id", "CountOfTracks", "Genre", "Name" },
                values: new object[] { 1, 3, "to my taste", "My" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AuthorId", "Genre", "Language", "Name", "Year" },
                values: new object[,]
                {
                    { 1, 1, "pop", "Ukrainian", "she-wolf", 2013 },
                    { 2, 2, "Latin pop", "Spanish", "Despacito", 2017 },
                    { 3, 3, "Pop", "English", "Cheri Cheri Lady", 1985 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayListTrack_TracksId",
                table: "PlayListTrack",
                column: "TracksId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AuthorId",
                table: "Tracks",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListTrack");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Autors");
        }
    }
}
