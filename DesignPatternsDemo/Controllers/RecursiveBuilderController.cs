using Microsoft.AspNetCore.Mvc;
using System;
using static DesignPatternsDemo.Model.RecursiveBuilderModel;

namespace DesignPatternsDemo.Controllers
{
    public class RecursiveBuilderController : Controller
    {
        public String Index()
        {
            var me = Employee.New
            .Called("ENA")
            .WorksAsA("Developer (Engineer)")
            .Born(DateTime.UtcNow)
            .Build();
                Console.WriteLine(me);

            var you = Employee.New
            .WorksAsA("Engineer")
            .Born(DateTime.UtcNow)
            .Called("Melih")
            .Build();
            Console.WriteLine(you);

            return me + "\n" + you;
        }
    }
}
