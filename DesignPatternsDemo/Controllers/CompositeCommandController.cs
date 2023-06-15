using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.CompositeCommandModel;

namespace DesignPatternsDemo.Controllers
{
    public class CompositeCommandController : Controller
    {
        public String Index()
        {
            StringBuilder sb = new StringBuilder();
            var ba = new BankAccount();
            var cmdDeposit = new BankAccountCommand(ba,
              BankAccountCommand.Action.Deposit, 100);
            var cmdWithdraw = new BankAccountCommand(ba,
              BankAccountCommand.Action.Withdraw, 1000);
            cmdDeposit.Call();
            cmdWithdraw.Call();
            sb.AppendLine(ba.ToString());
            cmdWithdraw.Undo();
            cmdDeposit.Undo();
            sb.AppendLine(ba.ToString());


            var from = new BankAccount();
            from.Deposit(100);
            var to = new BankAccount();

            var mtc = new MoneyTransferCommand(from, to, 1000);
            mtc.Call();


            // Deposited $100, balance is now 100
            // balance: 100
            // balance: 0

            sb.AppendLine(from.ToString());
            sb.AppendLine(to.ToString());

            return sb.ToString();
        }
    }
}
