using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DesignPatternsDemo.Model
{
    public class CompositePatternModel : PageModel
    {
        /*
         Objects can use other objects via inheritance or composition.
         Yazdigimiz fonksiyonlar tekil, composit ve scalar objelerin hepsine ayni anda hitap etmelidir. (Singular objects, scalar objects or composed objects need similar or identical behaviours.)
         Composite design pattern lets us treat both types of objects in a uniform fashion.
        */

        public class GraphicObject
        {
            public virtual string Name { get; set; } = "Group";
            public string Color;
            private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
            public List<GraphicObject> Children => children.Value;

            private void Print(StringBuilder sb, int depth)
            {
                sb.Append(new string('*', depth))
                  .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                  .AppendLine($"{Name}");
                foreach (var child in Children)
                    child.Print(sb, depth + 1);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                Print(sb, 0);
                return sb.ToString();
            }
        }

        public class Circle : GraphicObject
        {
            public override string Name => "Circle";
        }

        public class Square : GraphicObject
        {
            public override string Name => "Square";
        }

    }
}
