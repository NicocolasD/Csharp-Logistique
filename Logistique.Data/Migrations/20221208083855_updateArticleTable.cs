using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistique.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateArticleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks",
                column: "ArticleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks",
                column: "ArticleId");
        }
    }
}
