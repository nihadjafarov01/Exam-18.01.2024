using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}