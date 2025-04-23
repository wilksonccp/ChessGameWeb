namespace ChessGame.Models
{
    public class Move
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public GamePlay Game { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
