using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.ViewModels.Service;
using TestWebApp.Service.Interfaces;
using TestWebApp.Domain.Response;

namespace TestWebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var response = await _ServiceService.GetServices();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetService(int id)
        {
            var response = await _ServiceService.GetService(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _ServiceService.DeleteService(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetServices");
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

            var response = await _ServiceService.GetService(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ServiceId == 0)
                {
                    await _ServiceService.CreateService(model);
                }
                else
                {
                    await _ServiceService.Edit(model.ServiceId, model);
                }
            }

            return RedirectToAction("GetServices");
        }
    }
}
