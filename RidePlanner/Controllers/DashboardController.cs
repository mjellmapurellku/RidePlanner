using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePlanner.Models;

namespace RidePlanner.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}