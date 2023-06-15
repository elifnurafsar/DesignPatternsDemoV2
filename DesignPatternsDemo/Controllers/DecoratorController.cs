using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.DecoratorModel;

namespace DesignPatternsDemo.Controllers
{
    public class DecoratorController : Controller
    {
        public String Index()
        {
            StringBuilder sb = new StringBuilder();

            Dragon2 dragon2= new Dragon2 { age = 4, weight = 100 };
            sb.AppendLine(((ILizard)dragon2).Crawl());
            sb.AppendLine(((IBird)dragon2).Fly());
            sb.AppendLine(((ILizard)dragon2).SayYourWeight());
            sb.AppendLine(((IBird)dragon2).SayYourWeight());
            sb.AppendLine("**************************************");
            Dragon dragon = new Dragon();
            dragon.setAge(4);
            dragon.setWeight(100);
            sb.AppendLine(dragon.Fly());
            sb.AppendLine(dragon.Crawl());
            sb.AppendLine("**************************************");
            return sb.ToString();
        }
    }
}
