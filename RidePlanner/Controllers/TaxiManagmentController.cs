using Microsoft.AspNetCore.Mvc;
using RidePlanner.Services;
using RidePlanner.Filters;
using RidePlanner.Interfaces;
using RidePlanner.Models.Enums;
using RidePlanner.Models.TaxiRequest;
using RidePlanner.Models.Utilities;

namespace RidePlanner.Controllers
{
    [TypeFilter(typeof(BusinessOnlyFilter), Arguments = new object[] { "TaxiCompany" })]
    [Route("Business/TaxiManagement")]
    public class TaxiManagementController : Controller
    {
       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITaxiReservationService _taxiReservationService;

        public TaxiManagementController( IHttpContextAccessor httpContextAccessor, ITaxiReservationService taxiReservationService)
        {
          
            _httpContextAccessor = httpContextAccessor;
            _taxiReservationService = taxiReservationService;
        }

        [HttpGet("TaxiBookingManagement")]
        public IActionResult TaxiBookingManagement()
        {
            return View();
        }

        [HttpGet("TaxiReservationManagement")]
        public IActionResult TaxiReservationManagement()
        {
            return View();
        }



        [HttpGet("GetReservations")]
        public async Task<IActionResult> GetReservations()
        {
            try
            {
                var reservations = await _taxiReservationService.GetReservationsAsync();
                return Ok(new { success = true, reservations });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An internal server error occurred.", error = ex.Message });
            }
        }

        [HttpGet("GetTaxisByTaxiCompany")]
        public async Task<IActionResult> GetTaxisByTaxiCompany(int taxiCompanyId)
        {
            try
            {
                var taxis = await _taxiReservationService.GetTaxisByTaxiCompanyAsync(taxiCompanyId);

                return Ok(taxis);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, ResponseFactory.ErrorResponse(ResponseCodes.InternalServerError, ResponseMessages.InternalServerError));
            }
        }

        [HttpPut("UpdateReservation/{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId, [FromBody] UpdateTaxiReservationViewModel model)
        {
            try
            {
                var updated = await _taxiReservationService.UpdateReservationAsync(reservationId, model);

                if (!updated)
                    return NotFound(ResponseFactory.ErrorResponse(ResponseCodes.NotFound, "Reservation or Taxi not found."));

                return Ok(ResponseFactory.SuccessResponse("Reservation updated successfully.", updated));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ResponseFactory.ErrorResponse(ResponseCodes.InvalidData, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseFactory.ErrorResponse(ResponseCodes.InternalServerError, ResponseMessages.InternalServerError));
            }
        }
    }
}