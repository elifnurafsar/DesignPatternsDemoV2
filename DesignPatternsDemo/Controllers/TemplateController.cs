using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.TemplateModel;
namespace DesignPatternsDemo.Controllers
{
    public class TemplateController : Controller
    {
        public class Chess : Game
        {
            public Chess() : base(2)
            {
            }
            protected override string Start()
            {
                return ($"Starting a game of chess with {numberOfPlayers} players.");
            }
            protected override bool HaveWinner => turn == maxTurns;
            protected override string TakeTurn()
            {
                String s = ($"Turn {turn++} taken by player {currentPlayer}.");
                currentPlayer = (currentPlayer + 1) % numberOfPlayers;
                return s;
            }
            protected override int WinningPlayer => currentPlayer;
            private int maxTurns = 10;
            private int turn = 1;
        }
        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            var chess = new Chess();
            sb.AppendLine(chess.Run());
            return sb.ToString();
        }
    }
}