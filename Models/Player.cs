namespace ChessGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        public string Name { get; set; } // Player name or nickname
        public string Email { get; set; }
        public string Avatar { get; set; } // URL to the player's avatar image
        public bool IsBot { get; set; } = false; // Indicates if the player is a bot
        public string DisplayName => IsBot ? "ChesBoot" : Name;
        public string Password { get; set; } // Consider hashing this
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public List<GamePlay> GamesAsWhite { get; set; }
        public List<GamePlay> GamesAsBlack { get; set; }
    }
}
