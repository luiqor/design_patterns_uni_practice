using _02StrategyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace _02StrategyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sideLength, string polygonType)
        {
            var result = "";
            CalculatorContext figure = null;
            if (!string.IsNullOrEmpty(sideLength) && !string.IsNullOrEmpty(polygonType))
            {
                var side = double.Parse(sideLength.Trim());
                switch (polygonType)
                {
                    case "Triangle":
                        figure = new CalculatorContext(side, new TriangleStrategy()); //потрібно зробити щоб залежно від фігурки
                        break;
                    case "Quadrangle":
                        figure = new CalculatorContext(side, new QuadrangleStrategy());
                        break;
                    case "Hexagon":
                        figure = new CalculatorContext(side, new HexagonStrategy());
                        break;
                    case "Octagon":
                        figure = new CalculatorContext(side, new OctagonStrategy());
                        break;
                }
                if (figure != null) { 
                    double doubleResult = figure.ExecuteCalcArea();
                    result = $"{doubleResult}";
                }
            }
            ViewData["polygonType"] = polygonType;
            ViewData["sideLength"] = sideLength;
            return View("Index", result);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}