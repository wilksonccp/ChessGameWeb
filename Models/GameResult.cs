namespace ChessGame.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public string Result { get; set; } // Winner: "White", "Black", or "Draw"
        public string Reason { get; set; } // Reason for the result (e.g., "Checkmate", "Stalemate", etc.)
        public DateTime TimeStamp { get; set; } = DateTime.Now; // Date of the game

        // Relationship with the game
        public int GameId { get; set; }
        public ChessMatch Game { get; set; } // Navigation property to the game
    }
}
