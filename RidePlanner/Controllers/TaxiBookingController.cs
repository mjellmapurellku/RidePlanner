﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RidePlanner.Data;
using RidePlanner.Models.DTOs;
using RidePlanner.Models.Entities;
using RidePlanner.Models.Enums;
using RidePlanner.Models.Utilities;
using RidePlanner.ViewModel.Taxi;
using RidePlanner.ViewModel.TaxiModels;
using RidePlanner.Filters;
using RidePlanner.Interfaces;
using RidePlanner .Models.TaxiRequest;

namespace RidePlanner.Controllers
{
    [Route("api/TaxiBooking")]
    public class TaxiBookingController : Controller
    {
        private readonly ITaxiBookingService _taxiBookingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TaxiBookingController> _logger;

        public TaxiBookingController(ITaxiBookingService taxiBookingService, IHttpContextAccessor httpContextAccessor, ILogger<TaxiBookingController> logger)
        {
            _taxiBookingService = taxiBookingService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("SearchAvailableTaxis")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _taxiBookingService.GetAllCompaniesAsync();
                if (companies == null || !companies.Any())
                {
                    return Ok(ResponseFactory.ErrorResponse(ResponseCodes.NotFound, "No companies found."));
                }

                return Ok(new { success = true, companies });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, ResponseFactory.ErrorResponse(ResponseCodes.InternalServerError, ResponseMessages.InternalServerError));
            }
        }

        [ServiceFilter(typeof(LoginRequiredFilter))]
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid booking data provided.");
                return BadRequest(ResponseFactory.ErrorResponse(ResponseCodes.InvalidData, ResponseMessages.InvalidData));
            }

            var success = await _taxiBookingService.CreateBookingAsync(model);

            if (!success)
            {
                _logger.LogWarning("Booking creation failed for user with ID: {UserId}", model.UserId);
                return BadRequest(ResponseFactory.ErrorResponse(ResponseCodes.InvalidData, "Booking creation failed."));
            }

            _logger.LogInformation("Booking created successfully for user with ID: {UserId}", model.UserId);
            return Ok(ResponseFactory.SuccessResponse("Booking created successfully", success));
        }
    }
}