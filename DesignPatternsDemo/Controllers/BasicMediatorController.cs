using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using static DesignPatternsDemo.Model.BasicMediatorModel;

namespace DesignPatternsDemo.Controllers
{
    public class BasicMediatorController : Controller
    {
        public string Index()
        {
            return "Basic Mediator Test";
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
                Mediator mediator = new Mediator();
                var p1 = new Participant(mediator);
                var p2 = new Participant(mediator);

                Assert.That(p1.Value, Is.EqualTo(0));
                Assert.That(p2.Value, Is.EqualTo(0));

                p1.Say(2);

                Assert.That(p1.Value, Is.EqualTo(0));
                Assert.That(p2.Value, Is.EqualTo(2));

                p2.Say(4);

                Assert.That(p1.Value, Is.EqualTo(4));
                Assert.That(p2.Value, Is.EqualTo(2));
            }
        }
    }

}
