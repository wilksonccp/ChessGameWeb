using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace ChessGame.Models;

public class GamePlay
{
    public int Id { get; set; }

    // Game type (Human vs Human, Human vs AI, etc.)
    public string GameMode { get; set; } // "PVP", "PVE", "ONLINE"

    // Reference for players
    public int WhitePlayerId { get; set; }
    public Player WhitePlayer { get; set; }

    public int BlackPlayerId { get; set; }
    public Player BlackPlayer { get; set; }

    // Match status
    public bool IsActive { get; set; } = true;
    public bool IsCheckmate { get; set; } = false;
    public bool IsDraw { get; set; } = false;
    public string Turn { get; set; } = "White"; // ou "Black"

    // Start and end date
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime? EndTime { get; set; }

    // Navigation
    public List<Move> Moves { get; set; }
    //public GameResult Result { get; set; }

    public Board Board { get; set; } // Navigation property to the board state
}
