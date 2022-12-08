using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistique.Data.Migrations
{
    /// <inheritdoc />
    public partial class addReceptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks");

            migrationBuilder.CreateTable(
                name: "Receptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LigneReceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReceptionEntityId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneReceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LigneReceptions_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneReceptions_Receptions_ReceptionEntityId",
                        column: x => x.ReceptionEntityId,
                        principalTable: "Receptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_LigneReceptions_ArticleId",
                table: "LigneReceptions",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_LigneReceptions_ReceptionEntityId",
                table: "LigneReceptions",
                column: "ReceptionEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LigneReceptions");

            migrationBuilder.DropTable(
                name: "Receptions");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ArticleId",
                table: "Stocks",
                column: "ArticleId",
                unique: true);
        }
    }
}
