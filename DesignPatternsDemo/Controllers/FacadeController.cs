using Microsoft.AspNetCore.Mvc;
using static DesignPatternsDemo.Model.FacadeMagicSquareModel;
using System.Text;

namespace DesignPatternsDemo.Controllers
{
    public class FacadeController : Controller
    {
        public string Index()
        {
            var gen = new MagicSquareGenerator();
            var square = gen.Generate(3);
            return SquareToString(square);
        }

        private string SquareToString(List<List<int>> square)
        {
            var sb = new StringBuilder();
            foreach (var row in square)
            {
                sb.AppendLine(string.Join(" ",
                  row.Select(x => x.ToString())));
            }

            sb.AppendLine("*********************\n");

            return sb.ToString();
        }
    }
}
