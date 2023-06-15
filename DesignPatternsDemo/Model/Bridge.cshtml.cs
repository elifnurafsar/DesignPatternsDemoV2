using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    public class BridgeModel : PageModel
    {

        public interface IRenderer
        {
            String RenderCircle(float radius);
        }
        public class VectorRenderer : IRenderer
        {
            public String RenderCircle(float radius)
            {
                return "Drawing a circle of radius " + radius + " \n";
            }
        }

        public class RasterRenderer : IRenderer
        {
            public String RenderCircle(float radius)
            {
                return "Drawing pixels for circle of radius " + radius + " \n";
            }
        }

        public abstract class Shape
        {
            protected IRenderer renderer;

            // a bridge between the shape that's being drawn an
            // the component which actually draws it
            public Shape(IRenderer renderer)
            {
                this.renderer = renderer;
            }

            public abstract String Draw();
            public abstract void Resize(float factor);
        }

        public class Circle : Shape
        {
            private float radius;

            public Circle(IRenderer renderer, float radius) : base(renderer)
            {
                this.radius = radius;
            }

            public override String Draw()
            {
                return renderer.RenderCircle(radius);
            }

            public override void Resize(float factor)
            {
                radius *= factor;
            }
        }
        public void OnGet()
        {
        }
    }
}
