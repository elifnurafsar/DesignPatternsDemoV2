using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.ChainOfResponsibilityModel;

namespace DesignPatternsDemo.Controllers
{
    public class ChainOfResponsbilityController : Controller
    {
        public String Index()
        {
            StringBuilder sb= new StringBuilder();

            var goblin = new Creature("Goblin", 2, 2);
            sb.AppendLine(goblin.ToString());

            var root = new CreatureModifier(goblin);

            root.Add(new NoBonusesModifier(goblin));

            sb.AppendLine("Let's double goblin's attack...");
            root.Add(new DoubleAttackModifier(goblin));

            sb.AppendLine("Let's increase goblin's defense");
            root.Add(new IncreaseDefenseModifier(goblin));

            // eventually...
            root.Handle();
            sb.AppendLine(goblin.ToString());
            return sb.ToString();
        }
    }
}
