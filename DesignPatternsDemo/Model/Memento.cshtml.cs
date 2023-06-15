using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using static DesignPatternsDemo.Model.FacadeMagicSquareModel;
using System.IO;
namespace DesignPatternsDemo.Model
{
    public class MementoModel : PageModel
    {
        /*A token handle representing the system state.
        * Lets us roll back to the state when the token was generated.
        * May or may not directly expose state info.
        * */
        public class Memento
        {
            public int Balance { get; }
            public Memento(int balance)
            {
                Balance = balance;
            }
        }
        public class BankAccount
        {
            private int balance;
            private List<Memento> changes = new List<Memento>();
            private int current;
            public BankAccount(int balance)
            {
                this.balance = balance;
                changes.Add(new Memento(balance));
            }
            public Memento Deposit(int amount)
            {
                balance += amount;
                var m = new Memento(balance);
                changes.Add(m);
                ++current;
                return m;
            }
            public void Restore(Memento m)
            {
                if (m != null)
                {
                    balance = m.Balance;
                    changes.Add(m);
                    current = changes.Count - 1;
                }
            }
            public Memento Undo()
            {
                if (current > 0)
                {
                    var m = changes[--current];
                    balance = m.Balance;
                    return m;
                }
                return null;
            }
            public Memento Redo()
            {
                if (current + 1 < changes.Count)
                {
                    var m = changes[++current];
                    balance = m.Balance;
                    return m;
                }
                return null;
            }
            public override string ToString()
            {
                return $"{nameof(balance)}: {balance}";
            }
        }
    }
}