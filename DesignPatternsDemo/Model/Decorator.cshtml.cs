using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    //Try to add behaviour to existing calasses without altering them.

    public class DecoratorModel : PageModel
    {
        public interface ICreature
        {
            int age { get; set; }
        }

        public interface IBird : ICreature
        {
            public int weight { get; set; }
            public String Fly()
            {
                if (age >= 5)
                {
                    return "I am flying as a bird on the clouds....";
                }
                else
                    return "I am too small for flying ;(";
            }

            public String SayYourWeight()
            {
                if (age >= 2)
                {
                    return "My weight is " + weight + " kg";
                }
                else
                    return "Cik cik cikk!";
            }
        }

        public interface ILizard : ICreature
        {
            public int weight { get; set; }
            public String Crawl()
            {
                if (age >= 3)
                {
                    return "I am crawling as a liZard on the tree....";
                }
                else
                    return "I am too small for crawling ;(";
            }

            public String SayYourWeight()
            {
                if (age >= 2)
                {
                    return "My weight is " + weight + " kg";
                }
                else
                    return "Huhh @!";
            }
        }

        public class Bird : IBird
        {
            public int weight { get; set; }

            public int age
            {
                get; set;
            }

            public String Fly()
            {
                if (age >= 5)
                {
                    return "I am flying as a birD....";
                }
                else
                    return "I can't fly!";
            }
        }

        public class Lizard : ILizard
        {
            public int weight { get; set; }

            public int age
            {
                get; set;
            }
            public String Crawl()
            {
                if (age >= 3)
                {
                    return "I am crawling as a liZard....";
                }
                else
                    return "I can't crawl!";
            }
        }

        public class Dragon // no multiple inheritance
        {
            private readonly Bird bird;
            private readonly Lizard lizard;
            private int weight;
            private int age;

            public Dragon()
            {
                this.bird = new Bird();
                this.lizard = new Lizard();
            }

            public void setWeight(int value)
            {
                this.weight = value;
                this.bird.weight = value;
                this.lizard.weight = value;
            }

            public void setAge(int value)
            {
                this.age = value;
                this.bird.age = value;
                this.lizard.age = value;
            }

            public String Crawl()
            {
                return lizard.Crawl();
            }

            public String Fly()
            {
                return bird.Fly();
            }

        }

        public class Dragon2 : IBird, ILizard
        {
            public int weight {
                get;
                set; 
            }
            public int age
            {
                get;
                set;
            }

        }
    }
}
