using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabPractice1_FizzBuzz.Models;
using System.Text;

namespace LabPractice1_FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string input1, string input2, string range1, string range2)
        {
            var startNum = Convert.ToInt32(input1);
            var endNum = Convert.ToInt32(input2);
            var startRng = Convert.ToInt32(range1);
            var endRng = Convert.ToInt32(range2);

            for (var i = startRng; i <= endRng; i++)
            {
                if (i % startNum == 0 && i % endNum == 0)
                {
                    ViewData["Output"] += "FizzBuzz ";
                }
                else if (i % startNum == 0)
                {
                    ViewData["Output"] += "Fizz ";
                }
                else if (i % endNum == 0)
                {
                    ViewData["Output"] += "Buzz ";
                }
                else
                {
                    ViewData["Output"] += i + " ";
                }
            }

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
