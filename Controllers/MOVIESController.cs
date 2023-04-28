using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Data.Static;
using Samit_For_Entertainment.Data.ViewModels;

namespace Samit_For_Entertainment.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MOVIESController : Controller
    {
        private readonly IMOVIESSERVICE _service;

        public MOVIESController(IMOVIESSERVICE service)
        {
            _service = service;
        }
        //listing all movies
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMOVIES = await _service.GetAllAsync(n => n.CINAMA);
            return View(allMOVIES);
        }
        //movie details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var moviedetails = await _service.GetMovieByIdAsync(id);
            return View(moviedetails);
        }
        //craete a movie
        public async Task<IActionResult> Create()
        {
            var moviedropdownsData = await _service.GetNewMovieDropdownsValuesAsync();
            ViewBag.cinamas = new SelectList(moviedropdownsData.cinamas, "ID", "Name");
            ViewBag.actors = new SelectList(moviedropdownsData.actors, "ID", "FullName");
            ViewBag.producers = new SelectList(moviedropdownsData.producers, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedropdownsData = await _service.GetNewMovieDropdownsValuesAsync();
                ViewBag.cinamas = new SelectList(moviedropdownsData.cinamas, "ID", "Name");
                ViewBag.actors = new SelectList(moviedropdownsData.actors, "ID", "FullName");
                ViewBag.producers = new SelectList(moviedropdownsData.producers, "ID", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        //edit a movie
        public async Task<IActionResult> Edit(int id)
        {
            var moviedetail = await _service.GetMovieByIdAsync(id);
            if (moviedetail == null)
            {
                return View("Not Found");
            }
            var respones = new NewMovieVM()
            {
                ID = moviedetail.ID,
                Name = moviedetail.Name,
                Description = moviedetail.Description,
                Price = moviedetail.Price,
                StartDate = moviedetail.StartDate,
                EndDate = moviedetail.EndDate,
                ImageURL = moviedetail.ImageURL,
                MovieCategory = moviedetail.MovieCategory,
                CINAMAID = moviedetail.CINAMAID,
                PRODUCERID = moviedetail.PRODUCERID,
                ACTORIDS = moviedetail.ACTORS_MOVIES.Select(n => n.ACTORID).ToList(),
            };
            var moviedropdownsData = await _service.GetNewMovieDropdownsValuesAsync();
            ViewBag.cinamas = new SelectList(moviedropdownsData.cinamas, "ID", "Name");
            ViewBag.actors = new SelectList(moviedropdownsData.actors, "ID", "FullName");
            ViewBag.producers = new SelectList(moviedropdownsData.producers, "ID", "FullName");
            return View(respones);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.ID)
            {
                return View("Not Found");
            }
            if (!ModelState.IsValid)
            {
                var moviedropdownsData = await _service.GetNewMovieDropdownsValuesAsync();
                ViewBag.cinamas = new SelectList(moviedropdownsData.cinamas, "ID", "Name");
                ViewBag.actors = new SelectList(moviedropdownsData.actors, "ID", "FullName");
                ViewBag.producers = new SelectList(moviedropdownsData.producers, "ID", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMOVIES = await _service.GetAllAsync(n => n.CINAMA);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredresult = allMOVIES.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredresult);
            }
            return View("Index", allMOVIES);
        }
    }
}
