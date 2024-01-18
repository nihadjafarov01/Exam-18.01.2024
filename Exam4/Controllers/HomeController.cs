using Exam4.Business.Repositories.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam4.Controllers
{
    public class HomeController : Controller
    {
        IExpertService _service {  get; }

        public HomeController(IExpertService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllSync();
            var rdata = data.TakeLast(4);
            return View(rdata);
        }
    }
}