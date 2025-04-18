using Microsoft.EntityFrameworkCore;
using ChessGame.Models;

namespace ChessGame.Data;

public class ChessDbContext : DbContext
{
    public ChessDbContext(DbContextOptions<ChessDbContext> options)
        : base(options)
    {
    }
    public DbSet<Game> ChessGames { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<GameResult> GameResults { get; set; }
}
