using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Data.Static;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class PRODUCERSController : Controller
    {
        private readonly IPRODUCERSSERVIC _service;

        public PRODUCERSController(IPRODUCERSSERVIC service)
        {
            _service = service;
        }
        // listing all producers
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPRODUCERS = await _service.GetAllAsync();
            return View(allPRODUCERS);
        }
        //PRODUCER DETAILS 
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetasils = await _service.GetByIdAsync(id);
            if (producerDetasils == null)
            {
                return View("Not Found");
            }
            return View(producerDetasils);
        }
        //ADD PRODUCER
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] PRODUCER producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //UPDATE PRODUCER 
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");
            }
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID, FullName, ProfilePictureURL, Bio")] PRODUCER producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.ID)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);

        }
        //DELET 
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");
            }
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            { return View("Not Found"); }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
