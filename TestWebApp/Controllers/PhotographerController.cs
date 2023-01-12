using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.ViewModels.Photographer;
using TestWebApp.Domain.Response;
using TestWebApp.Service.Interfaces;

namespace TestWebApp.Controllers
{
    public class PhotographerController : Controller
    {
        private readonly IPhotographerService _PhotographerService;

        public PhotographerController(IPhotographerService PhotographerService)
        {
            _PhotographerService = PhotographerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotographers()
        {
            var response = await _PhotographerService.GetPhotographers();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotographer(int id)
        {
            var response = await _PhotographerService.GetPhotographer(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _PhotographerService.DeletePhotographer(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetPhotographers");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _PhotographerService.GetPhotographer(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(PhotographerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PhotographerId == 0)
                {
                    await _PhotographerService.CreatePhotographer(model);
                }
                else
                {
                    await _PhotographerService.Edit(model.PhotographerId, model);
                }
            }

            return RedirectToAction("GetPhotographers");
        }
    }
}
