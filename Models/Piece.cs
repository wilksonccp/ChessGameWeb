namespace ChessGame.Models
{
    public class Piece
    {
        public int Id { get; set; }
        public string Type { get; set; } // Piece Type: Pawn, Rook, Knight, Bishop, Queen, King
        public string Color { get; set; } // Piece color: "White" or "Black"
        public int Position { get; set; } // Current board position, e.g. "e4"
        public int MoveCount { get; set; }
        public bool IsCaptured { get; set; } // Is the piece still active in the game?
        public bool IsPromoted { get; set; }
        public bool IsInCheck { get; set; }
        public int GameId { get; set; } // Which game does this piece belong to?
        public ChessMatch Game { get; set; }
    }
}
