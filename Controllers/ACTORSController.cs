using Microsoft.AspNetCore.Mvc;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Controllers
{
    public class ACTORSController : Controller
    {
        private readonly IACTORSSERVICE _service;

        public ACTORSController(IACTORSSERVICE service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //get actors/creat
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] ACTOR actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID, FullName, ProfilePictureURL, Bio")] ACTOR actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);

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
