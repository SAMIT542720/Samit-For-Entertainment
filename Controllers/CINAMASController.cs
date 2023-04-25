using Microsoft.AspNetCore.Mvc;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Controllers
{
    public class CINAMASController : Controller
    {
        private readonly ICINAMASSERVICE _service;

        public CINAMASController(ICINAMASSERVICE service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCINAMAS = await _service.GetAllAsync();
            return View(allCINAMAS);
        }
        //get actors/creat
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")] CINAMA cinama)
        {
            if (!ModelState.IsValid)
            {
                return View(cinama);
            }
            await _service.AddAsync(cinama);
            return RedirectToAction(nameof(Index));
        }
        //Get actor/details
        public async Task<IActionResult> Details(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null) { return View("Not Found"); }
            return View(actordetails);
        }
        //Edit actor :update
        public async Task<IActionResult> Edit(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null)
            {
                return View("Not Found");
            }
            return View(actordetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Logo, Name, Description")] CINAMA cinama)
        {

            if (!ModelState.IsValid)
            {
                return View(cinama);
            }
            await _service.UpdateAsync(id, cinama);

            return RedirectToAction(nameof(Index));
        }
        //Edit actor :DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Not Found");
            }
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) { return View("Not Found"); }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
