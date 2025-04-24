using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessGame.Migrations
{
    /// <inheritdoc />
    public partial class AddGameResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    MoveCount = table.Column<int>(type: "int", nullable: false),
                    IsCaptured = table.Column<bool>(type: "bit", nullable: false),
                    IsPromoted = table.Column<bool>(type: "bit", nullable: false),
                    IsInCheck = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_ChessGames_GameId",
                        column: x => x.GameId,
                        principalTable: "ChessGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_ChessGames_GameId",
                        column: x => x.GameId,
                        principalTable: "ChessGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_GameId",
                table: "Pieces",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameId",
                table: "Result",
                column: "GameId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "Result");
        }
    }
}
