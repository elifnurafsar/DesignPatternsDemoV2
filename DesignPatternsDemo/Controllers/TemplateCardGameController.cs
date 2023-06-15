using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Text;
using static DesignPatternsDemo.Model.IteratorModel;
using static DesignPatternsDemo.Model.TemplateCardGameModel;

namespace DesignPatternsDemo.Controllers
{
    public class TemplateCardGameController : Controller
    {
        public String Index()
        {
            StringBuilder sb = new StringBuilder();
            Creature BerkS = new Creature(24, 36);
            Creature TolgaG = new Creature(6, 24);
            Creature ZeynepA = new Creature(26, 36);
            Creature BirsenCD = new Creature(6, 20);
            Creature[] cs = new Creature[4];
            cs[0] = BerkS;
            cs[1] = TolgaG;
            cs[2] = ZeynepA;
            cs[3] = BirsenCD;
            TemporaryCardDamageGame FinalExam = new TemporaryCardDamageGame(cs);
            int ex1 = FinalExam.Combat(0, 1);
            sb.Append("Results of the first exam between Berk and Tolga: ");
            sb.Append(ex1);
            PermanentCardDamage FinalExam2 = new PermanentCardDamage(cs);
            ex1 = FinalExam2.Combat(2, 3);
            sb.Append("\nResults of the first exam between Zeynep and Birsen: ");
            sb.Append(ex1);
            return sb.ToString();

        }
    }
}


namespace Coding.Exercise.Tests
{
    [TestFixture]
    public class TestTemplatePattern
    {
        Creature BerkS = new Creature(24, 36);
        Creature TolgaG = new Creature(6, 24);
        Creature ZeynepA = new Creature(26, 36);
        Creature BirsenCD = new Creature(6, 20);
        Creature[] cs = new Creature[2];
        
        [Test]
        public void Test()
        {
            cs[0] = BerkS;
            cs[1] = TolgaG;
            TemporaryCardDamageGame FinalExam = new TemporaryCardDamageGame(cs);
            int ex = FinalExam.Combat(0, 1);
            Assert.AreEqual(ex, 0);
        }

        [Test]
        public void Test2()
        {
            cs[0] = ZeynepA;
            cs[1] = BirsenCD;
            TemporaryCardDamageGame FinalExam = new TemporaryCardDamageGame(cs);
            int ex = FinalExam.Combat(0, 1);
            Assert.AreEqual(ex, 0);
        }
    }
}
