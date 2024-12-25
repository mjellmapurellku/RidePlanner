using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RidePlanner.Data;
using RidePlanner.Data;
using RidePlanner.Models;
using System.Diagnostics;

namespace RidePlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await _context.UserReviews.AsNoTracking().ToListAsync();

            return View(reviews);
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult UserActivity()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}