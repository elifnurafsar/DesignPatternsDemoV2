using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.CompositeCommandModel;
using static DesignPatternsDemo.Model.NullObjectModel;
namespace DesignPatternsDemo.Controllers
{
    public class NullObjectController : Controller
    {
        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            var log = Null<ILog>.Instance;
            var ba = new Model.NullObjectModel.BankAccount(log);
            sb.AppendLine(ba.Deposit(100));
            sb.AppendLine(ba.Withdraw(200));
            return sb.ToString();
        }
    }
}