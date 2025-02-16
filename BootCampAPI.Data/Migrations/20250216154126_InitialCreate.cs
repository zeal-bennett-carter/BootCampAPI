using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCampAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookSeries",
                columns: table => new
                {
                    BookSeriesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSeries", x => x.BookSeriesId);
                    table.ForeignKey(
                        name: "FK_BookSeries_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorID = table.Column<int>(type: "INTEGER", nullable: false),
                    BookSeriesID = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PagesRead = table.Column<int>(type: "INTEGER", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_BookSeries_BookSeriesID",
                        column: x => x.BookSeriesID,
                        principalTable: "BookSeries",
                        principalColumn: "BookSeriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookSeriesID",
                table: "Book",
                column: "BookSeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_BookSeries_AuthorId",
                table: "BookSeries",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookSeries");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
