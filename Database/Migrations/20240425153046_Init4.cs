using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientApp.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Autors_AuthorId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AuthorId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Tracks");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Author",
                value: "Oleg Vinnik");

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Author",
                value: "Luis Fonsi");

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Author",
                value: "Modern Talking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Tracks");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuthorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "AuthorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuthorId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AuthorId",
                table: "Tracks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Autors_AuthorId",
                table: "Tracks",
                column: "AuthorId",
                principalTable: "Autors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
