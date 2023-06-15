using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DesignPatternsDemo.Model.BridgeModel;

namespace DesignPatternsDemo.Model
{
    public class YieldDenemeModel : PageModel
    {
        public IEnumerable<int> Result()
        {
            return EvenNumbersWithYield(1, 20);
        }
        public static IEnumerable<int> EvenNumbersWithYield(int lowerBound, int upperBound)
        {
            for(int i=lowerBound; i<upperBound; i++)
            {
                if( i % 2 == 0)
                    yield return i;
            }
        }
    }
}
