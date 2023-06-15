using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Text;
using static DesignPatternsDemo.Model.StrategyModel;

namespace DesignPatternsDemo.Controllers
{
    public class StrategyController : Controller
    {
        public String Index()
        {
            StringBuilder sb = new StringBuilder();
            var people = new List<ModelApplicant>();
            people.Add(new ModelApplicant(111, "Alina", 25, 175, 50, 90, 62, 89));
            people.Add(new ModelApplicant(112, "Melina", 23, 178, 49, 86, 60, 88));
            people.Add(new ModelApplicant(113, "Salina", 21, 182, 51, 88, 60, 90));
            people.Add(new ModelApplicant(114, "Elina", 23, 179, 48, 87, 61, 89));
            people.Add(new ModelApplicant(115, "Polina", 22, 178, 49, 86, 60, 90));
            people.Sort(); // meaningless by default
                           // sort by name with a lambda
            people.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var person in people)
            {
                sb.Append(person.Name + " ");
            }
            sb.AppendLine();
            people.Sort(ModelApplicant.NameComparer);
            foreach (var person in people)
            {
                sb.Append(person.Name + " ");
            }
            sb.AppendLine();
            people.Sort(ModelApplicant.AgeComparer);
            foreach (var person in people)
            {
                sb.Append(person.Name + " ");
            }
            sb.AppendLine();
            people.Sort(ModelApplicant.HeightComparer);
            foreach (var person in people)
            {
                sb.Append(person.Name + ": " + person.Height + " ");
            }
            return sb.ToString();
        }
    }
}


namespace Coding.Exercise.Tests
{
    [TestFixture]
    public class TestStrategyPattern
    {
        StringBuilder sb = new StringBuilder();
        List<ModelApplicant> people = new List<ModelApplicant>();
        ModelApplicant alina = new ModelApplicant(111, "Alina", 25, 175, 50, 90, 62, 89);
        ModelApplicant melina = new ModelApplicant(112, "Melina", 23, 178, 49, 86, 60, 88);
        ModelApplicant salina = new ModelApplicant(113, "Salina", 21, 182, 51, 88, 60, 90);
        ModelApplicant elina = new ModelApplicant(114, "Elina", 23, 179, 48, 87, 61, 89);
        ModelApplicant polina = new ModelApplicant(115, "Polina", 22, 178, 49, 86, 60, 90);
        [Test]
        public void Test()
        {
            people.Add(alina);
            people.Add(melina);
            people.Add(salina);
            people.Add(elina);
            people.Add(polina);
            List<ModelApplicant> trueList = new List<ModelApplicant>();
            trueList.Add(alina);
            trueList.Add(elina);
            trueList.Add(melina);
            trueList.Add(polina);
            trueList.Add(salina);
            people.Sort((x, y) => x.Name.CompareTo(y.Name));
            CollectionAssert.AreEqual(people, trueList);
        }

        [Test]
        public void Test2()
        {
            melina.Age = 26;
            people.Add(alina);
            people.Add(melina);
            people.Add(salina);
            people.Add(elina);
            people.Add(polina);
            List<ModelApplicant> trueList = new List<ModelApplicant>();
            trueList.Add(salina);
            trueList.Add(polina);
            trueList.Add(elina);
            trueList.Add(alina);
            trueList.Add(melina);
            people.Sort(ModelApplicant.AgeComparer);
            CollectionAssert.AreEqual(people, trueList);
            Assert.True(true);
        }

        [Test]
        public void Test3()
        {
            melina.Height = 174;
            people.Add(alina);
            people.Add(melina);
            people.Add(salina);
            people.Add(elina);
            people.Add(polina);
            List<ModelApplicant> trueList = new List<ModelApplicant>();
            trueList.Add(melina);
            trueList.Add(alina);
            trueList.Add(polina);
            trueList.Add(elina);
            trueList.Add(salina);
            people.Sort(ModelApplicant.HeightComparer);
            CollectionAssert.AreEqual(people, trueList);
            Assert.True(true);
        }
    }
}