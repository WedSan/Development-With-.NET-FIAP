using checkpoint_1_2_semester.Models;
using checkpoint_1_2_semester.Services;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint_1_2_semester.Controllers
{
    public class ToysController : Controller
    {
        private readonly IToyService _toyService;
        private readonly ILogger<ToysController> _logger;

        public ToysController(IToyService toyService, ILogger<ToysController> logger)
        {
            _toyService = toyService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var toys = await _toyService.GetAllToysAsync();
            return View(toys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Toy toy)
        {
            if (ModelState.IsValid)
            {
                await _toyService.AddToyAsync(toy);
                return RedirectToAction(nameof(Index));
            }
            return View(toy);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var toy = await _toyService.GetToyByIdAsync(id);
            if (toy == null)
            {
                return NotFound();
            }
            return View(toy);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Toy toy)
        {
            if (id != toy.ToyId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _toyService.UpdateToyAsync(toy);
                return RedirectToAction(nameof(Index));
            }
            return View(toy);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var toy = await _toyService.GetToyByIdAsync(id);
            if (toy == null)
            {
                return NotFound();
            }
            return View(toy);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ToyId)
        {
            _logger.LogInformation("Deleting toy with ID: {ToyId}", ToyId);
            await _toyService.DeleteToyAsync(ToyId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var toy = await _toyService.GetToyByIdAsync(id);
            if (toy == null)
            {
                return NotFound();
            }
            return View(toy);
        }
    }
}


