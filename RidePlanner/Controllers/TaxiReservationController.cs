using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RidePlanner.Data;
using RidePlanner.Interfaces;
using RidePlanner.Models.Entities;
using RidePlanner.Models.Enums;
using RidePlanner.Models.TaxiRequest;
using WebApplication1.Filters;

namespace RidePlanner.Controllers
{
    [Route("api/TaxiReservation")]
    public class TaxiReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITaxiReservationService _taxiReservationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaxiReservationController(AppDbContext context, ITaxiReservationService taxiReservationService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _taxiReservationService = taxiReservationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("SearchAvailableTaxis")]
        public async Task<IActionResult> SearchAvailableTaxis()
        {
            var taxiCompanies = await _taxiReservationService.SearchAvailableTaxisAsync();

            return Ok(new { success = true, companies = taxiCompanies });
        }

       
    }
}