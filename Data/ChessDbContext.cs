using Microsoft.EntityFrameworkCore;
using ChessGame.Models;

namespace ChessGame.Data;

public class ChessDbContext : DbContext
{
    public ChessDbContext(DbContextOptions<ChessDbContext> options)
        : base(options)
    {
    }
    public DbSet<Models.GamePlay> ChessGames { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<GameResult> Result { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<GamePlay>()
            .HasOne(g => g.Result)
            .WithOne(r => r.Game)
            .HasForeignKey<GameResult>(r => r.GameId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<GamePlay>()
            .HasOne(g => g.Board)
            .WithOne(b => b.Game)
            .HasForeignKey<Board>(b => b.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship: Player as WhitePlayer
        modelBuilder.Entity<GamePlay>()
            .HasOne(g => g.WhitePlayer)
            .WithMany(p => p.GamesAsWhite)
            .HasForeignKey(g => g.WhitePlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship: Player as BlackPlayer
        modelBuilder.Entity<GamePlay>()
            .HasOne(g => g.BlackPlayer)
            .WithMany(p => p.GamesAsBlack)
            .HasForeignKey(g => g.BlackPlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
