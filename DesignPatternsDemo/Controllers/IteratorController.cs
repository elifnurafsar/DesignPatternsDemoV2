using Microsoft.AspNetCore.Mvc;
using static DesignPatternsDemo.Model.IteratorModel;
using System.Text;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace DesignPatternsDemo.Controllers
{
    public class IteratorController : Controller
    {
        public String Index()
        {
            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var tree = new BinaryTree<int>(root);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Join(",", tree.InOrder.Select(x => x.Value)));
            var node = new Node<char>('a',
             new Node<char>('b',
               new Node<char>('c'),
               new Node<char>('d')),
             new Node<char>('e'));
            var tree2 = new BinaryTree<char>(node);
            sb.AppendLine(String.Join(",", tree2.PreOrder.Select(x => x.Value)));
            return sb.ToString();
        }
    }
}

namespace Coding.Exercise.Tests
{
    [TestFixture]
    public class TestSuite
    {
        [Test]
        public void Test()
        {
            var node = new Node<char>('a',
              new Node<char>('b',
                new Node<char>('c'),
                new Node<char>('d')),
              new Node<char>('e'));
            var tree = new BinaryTree<char>(node);
            Assert.That(String.Join(",", tree.PreOrder.Select(x => x.Value)), Is.EqualTo("a,b,c,d,e"));
        }
    }
}