using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
namespace DesignPatternsDemo.Model
{
    public class TemplateModel : PageModel
    {
        /* A high level blueprint for an algorithm to be completed by inheritors. */
        /* Strategy method does it through composition (uses interface). Concrete implementations implement the interface.*/
        /* In template pattern, overall algorithm makes use of abstract member. Inheritors override the abstract members.*/
        public abstract class Game
        {
            public string Run()
            {
                StringBuilder sb = new StringBuilder();
                Start();
                while (!HaveWinner)
                    sb.AppendLine(TakeTurn());
                sb.AppendLine($"Player {WinningPlayer} wins.");
                return sb.ToString();
            }
            protected abstract string Start();
            protected abstract bool HaveWinner { get; }
            protected abstract string TakeTurn();
            protected abstract int WinningPlayer { get; }
            protected int currentPlayer;
            protected readonly int numberOfPlayers;
            public Game(int numberOfPlayers)
            {
                this.numberOfPlayers = numberOfPlayers;
            }
        }
    }
}