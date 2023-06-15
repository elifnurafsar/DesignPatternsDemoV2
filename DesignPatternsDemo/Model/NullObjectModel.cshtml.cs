using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using ImpromptuInterface;
using static System.Console;
namespace DesignPatternsDemo.Model
{
    /*When a component X uses another component Y it assumes that Y is non-null*/
    /*Null object is a no-op object that conforms the required interface, satisfying a dependency requirement of some other object */
    public class NullObjectModel : PageModel
    {
        public interface ILog
        {
            string Info(string msg);
            string Warn(string msg);
        }
        class ConsoleLog : ILog
        {
            public string Info(string msg)
            {
                return (msg);
            }
            public string Warn(string msg)
            {
                return ("WARNING: " + msg);
            }
        }
        public class BankAccount
        {
            private ILog log;
            private int balance;
            public BankAccount(ILog log)
            {
                this.log = log;
            }
            public string Deposit(int amount)
            {
                balance += amount;
                // check for null everywhere
                return $"Deposited ${amount}, balance is now {balance}";
            }
            public string Withdraw(int amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    return $"Withdrew ${amount}, we have ${balance} left";
                }
                else
                {
                    return $"Could not withdraw ${amount} because balance is only ${balance}";
                }
            }
        }
        public sealed class NullLog : ILog
        {
            public string Info(string msg)
            {
                return "";
            }
            public string Warn(string msg)
            {
                return "";
            }
        }
        public class Null<T> : DynamicObject where T : class
        {
            public static T Instance
            {
                get
                {
                    if (!typeof(T).IsInterface)
                        throw new ArgumentException("I must be an interface type");
                    return new Null<T>().ActLike<T>();
                }
            }
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                result = Activator.CreateInstance(binder.ReturnType);
                return true;
            }
        }
    }
}