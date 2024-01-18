using Exam4.Business.Repositories.Services.Interfaces;
using Exam4.Business.ViewModels.ExpertVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam4.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ExpertController : Controller
    {
        IExpertService _service {  get; }

        public ExpertController(IExpertService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllSync();
            return View(data);
        }
        public  IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public  IActionResult Create(ExpertCreateVM vm)
        {
            _service.Create(vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _service.UpdateAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ExpertUpdateVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
    }
}
