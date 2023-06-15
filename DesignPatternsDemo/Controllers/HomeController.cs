using Microsoft.AspNetCore.Mvc;
using System.Text;
using static DesignPatternsDemo.Model.BridgeModel;
using static DesignPatternsDemo.Model.FacadeMagicSquareModel;

namespace DesignPatternsDemo.Controllers
{


    public class HomeController : Controller
    {
        // GET: /HomeController/

        public string Index()
        {
            var raster = new Model.BridgeModel.RasterRenderer();
            var vector = new VectorRenderer();
            var circle = new Circle(vector, 5);
            String s = circle.Draw();
            circle.Resize(2);
            s += circle.Draw();
            var circle2 = new Circle(raster, 3);
            s += circle2.Draw();
            circle2.Resize(4);
            s += circle2.Draw();
            return s + "End";
        }

        // GET: /HomeController/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
