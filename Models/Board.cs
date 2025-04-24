namespace ChessGame.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Layout { get; set; } // Compact representation of the board state (e.g. FEN, JSON, etc.)
        public DateTime Timestamp { get; set; } = DateTime.Now; // Creation or update timestamp
        public int GameId { get; set; } // Which game does this board belong to?
        public ChessMatch Game { get; set; } // Navigation property to the game
    }
}
