using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.MementoModel;
namespace DesignPatternsDemo.Controllers
{
    public class MementoController : Controller
    {
        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Acount created");
            var ba = new BankAccount(100);
            sb.AppendLine(ba.ToString());
            ba.Deposit(50);
            sb.AppendLine(ba.ToString());
            ba.Deposit(25);
            sb.AppendLine(ba.ToString());
            ba.Undo();
            sb.AppendLine($"Undo 1: {ba}");
            ba.Undo();
            sb.AppendLine($"Undo 2: {ba}");
            ba.Redo();
            sb.AppendLine($"Redo 2: {ba}");
            return sb.ToString();
        }
    }
}