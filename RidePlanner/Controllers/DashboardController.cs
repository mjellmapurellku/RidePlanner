using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePlanner.Models;
using RidePlanner.Filters;


namespace RidePlanner.Controllers
{
    [ServiceFilter(typeof(AdminOnlyFilter))]
    public class DashboardController : Controller
    {

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}