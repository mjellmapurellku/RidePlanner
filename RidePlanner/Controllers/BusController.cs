using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePlanner.Models;

namespace RidePlanner.Controllers
{
    public class BusController : Controller
    {

        public IActionResult BusSchedules()
        {
            return View();
        }

    }
}