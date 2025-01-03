using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePlanner.Models;
using RidePlanner.Filters;
using AutoMapper;
using RidePlanner.Data;
using RidePlanner.Interfaces;
using RidePlanner.ViewModel.Bus;
using RidePlanner.Models.TaxiRequest;
using RidePlanner.Services;
using RidePlanner.Models.Enums;
using RidePlanner.Models.Utilities;
using System.Linq;


namespace RidePlanner.Controllers
{
    [ServiceFilter(typeof(AdminBaseFilter))]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IBusCompanyService _busCompanyService;
        private readonly ITaxiCompanyService _taxiCompanyService;
        private readonly IDriverDashboardService _dashboardService;
        public DashboardController(ITaxiCompanyService taxiCompanyService, IBusCompanyService busCompanyService, IDashboardService dashboardService)
        {
            _taxiCompanyService = taxiCompanyService;
            _busCompanyService = busCompanyService;
            _dashboardService = dashboardService;
        }

        public IActionResult Dashboard()
        {
            var model = _dashboardService.GetDashboardData();
            return View(model);
        }

        [HttpGet("Bus")]
        public IActionResult Bus()
        {
            var busCompanies = _busCompanyService.GetAllBusCompanies();
            var viewModel = new ManageBusCompanyViewModel
            {
                BusCompanies = busCompanies
            };

            return View(viewModel);
        }

        [HttpGet("Taxi")]
        public IActionResult Taxi()
        {
            var taxiCompanies = _taxiCompanyService.GetAllCompanies();

            var viewModel = new ManageTaxiCompanyRequest
            {
                TaxiCompanies = taxiCompanies
            };

            return View(viewModel);
        }
    }
}