using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.StepWiseBuilderModel;

namespace DesignPatternsDemo.Controllers
{
    public class StepWiseBuilderController : Controller
    {
        public String Index()
        {
            StringBuilder sb = new StringBuilder();
            Car car = CarBuilder.Create()
            .OfType(CarType.Crossover)
            .WithWheels(22)
            .Build();
            sb.Append(car.ToString());

            sb.AppendLine();
            Car car2 = CarBuilder.Create()
            .OfType(CarType.Sport)
            .WithWheels(20)
            .Build();
            sb.AppendLine(car2.ToString());

            try
            {
                sb.AppendLine();
                Car car3 = CarBuilder.Create()
                .OfType(CarType.Sport)
                .WithWheels(30)
                .Build();
                sb.AppendLine(car3.ToString());
            }
            catch(ArgumentException e) {
                sb.AppendLine(e.Message);
            }
            

            return sb.ToString();
        }
    }
}
