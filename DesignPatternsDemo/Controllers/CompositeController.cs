using Microsoft.AspNetCore.Mvc;
using static DesignPatternsDemo.Model.CompositePatternModel;

namespace DesignPatternsDemo.Controllers
{
    public class CompositeController : Controller
    {
        public String Index()
        {
            /*var model = new Model.YieldDenemeModel();
            IEnumerable<int> enumerable = model.Result();
            String s = "";
            foreach (var item in enumerable)
            {
                s += item + "\n";
            }
            return s;*/
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            return drawing.ToString();
        }

        public string Demo()
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            return drawing.ToString();
        }
    }
}
