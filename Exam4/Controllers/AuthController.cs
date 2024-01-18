using Exam4.Business.Repositories.Services.Interfaces;
using Exam4.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Mvc;

namespace Exam4.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service { get; }

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (await _service.Register(vm))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(vm);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (await _service.Login(vm))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(vm);
            }
        }
        public async Task<bool> CreateInit()
        {
            return await _service.CreateInit();
        }
    }
}
