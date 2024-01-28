using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuoteCategories",
                columns: table => new
                {
                    QuoteCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteCategories", x => x.QuoteCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    QuoteCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_QuoteCategories_QuoteCategoryId",
                        column: x => x.QuoteCategoryId,
                        principalTable: "QuoteCategories",
                        principalColumn: "QuoteCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuoteCategories",
                columns: new[] { "QuoteCategoryId", "Category" },
                values: new object[,]
                {
                    { 1, "Movies" },
                    { 2, "Inspirational" },
                    { 3, "Love" },
                    { 4, "Humerous" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "QuoteCategoryId", "Text", "Year" },
                values: new object[,]
                {
                    { 1, "Gone with the Wind", 1, "Frankly, my dear, I don't give a damn.", 1939 },
                    { 2, "Jerry Maguire", 1, "You had mne at \"Hello\".", 1996 },
                    { 3, "The Shining", 1, "Here's Johnny.", 1980 },
                    { 4, "Martin Luther King, Jr.", 2, "Out of the mountain of despair, a stone of hope.", null },
                    { 5, "Carol Burnett", 2, "When you have a dream, you've got to grab it and never let go.", null },
                    { 6, "Michael Altshuler", 2, "The bad news is time flies. The good news is you're the pilot.", null },
                    { 7, "Sir Arthur Conan Doyle, The White Company", 3, "You are my heart, my life, my one and only thought.", null },
                    { 8, "Henry David Thoreau", 3, "There is no remedy for love but to love more.", null },
                    { 9, "Bertrand Russell, The Conquest of Happiness", 3, "Of all forms of caution, caution in love is perhaps the most fatal to true happiness.", null },
                    { 10, "Rose (Betty White), \"The Golden Girls\"", 4, "My mother always used to say: The older you get,the better you get,unless you’re a banana.", null },
                    { 11, "David Lettermn", 4, "Halloween is the beginning of the holiday shopping season. That’s for women. The beginning of the holiday shopping season for men is Christmas Eve.", null },
                    { 12, "Mark Twain", 4, "Clothes make the man. Naked people have little or no influence in society.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteCategoryId",
                table: "Quotes",
                column: "QuoteCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteCategories");
        }
    }
}
