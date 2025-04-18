using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace ChessGame.Models
{
    public class ChessGame
    {
        public int Id { get; set; }

        // Tipo de jogo (Humano vs Humano, Humano vs IA, etc.)
        public string GameMode { get; set; } // "PVP", "PVE", "ONLINE"

        // Referência para os jogadores
        public int WhitePlayerId { get; set; }
        public Player WhitePlayer { get; set; }

        public int BlackPlayerId { get; set; }
        public Player BlackPlayer { get; set; }

        // Estado da partida
        public bool IsActive { get; set; } = true;
        public bool IsCheckmate { get; set; } = false;
        public bool IsDraw { get; set; } = false;
        public string Turn { get; set; } = "White"; // ou "Black"

        // Data de início e fim
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }

        // Navegação
        public List<Move> Moves { get; set; }
        public GameResult Result { get; set; }
    }
}
