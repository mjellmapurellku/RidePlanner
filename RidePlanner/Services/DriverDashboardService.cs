using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RidePlanner.Data;
using RidePlanner.Interfaces;
using RidePlanner.Models.Enums;
using RidePlanner.Models.TaxiRequest;
using Microsoft.Extensions.Logging;


namespace RidePlanner.Services
{

    public class DriverDashboardService : IDriverDashboardService
    {
        private readonly IAuthenticateService _authService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverDashboardService> _logger;

        public DriverDashboardService(AppDbContext context, IAuthenticateService authService, IMapper mapper, ILogger<DriverDashboardService> logger)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<TaxiBookingViewModel>> GetAllBookingsAsync()
        {
            var driverId = _authService.GetCurrentUserId();

            if (driverId == null)
            {
                _logger.LogWarning("Attempt to fetch bookings failed: driver is not authenticated.");
                return new List<TaxiBookingViewModel>();
            }

            try
            {
                _logger.LogInformation("Fetching bookings for driver ID: {DriverId}", driverId);

                var bookings = await _context.TaxiBookings
                    .Where(b => b.Status == ReservationStatus.Pending)
                    .Include(b => b.User)
                    .Include(b => b.Taxi)
                    .ThenInclude(t => t.Driver)
                    .Where(t => t.DriverId == driverId.Value)
                    .ToListAsync();

                _logger.LogInformation("Successfully fetched {Count} bookings for driver ID: {DriverId}", bookings.Count, driverId);

                return _mapper.Map<List<TaxiBookingViewModel>>(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching bookings for driver ID: {DriverId}", driverId);
                return new List<TaxiBookingViewModel>();
            }
        }
        public async Task<bool> ClaimBookingAsync(int bookingId)
        {
            var driverId = _authService.GetCurrentUserId();

            if (driverId == null)
            {
                _logger.LogWarning("Attempt to claim booking failed: driver is not authenticated.");
                return false;
            }

            try
            {
                _logger.LogInformation("Driver ID: {DriverId} attempting to claim booking ID: {BookingId}", driverId, bookingId);

                var booking = await _context.TaxiBookings
                    .Include(b => b.Taxi)
                    .ThenInclude(t => t.Driver)
                    .FirstOrDefaultAsync(b => b.BookingId == bookingId && b.Status == ReservationStatus.Pending);

                if (booking == null)
                {
                    _logger.LogWarning("Booking ID: {BookingId} not found or not in pending status for driver ID: {DriverId}", bookingId, driverId);
                    return false;
                }

                if (booking.Taxi.DriverId != driverId.Value)
                {
                    _logger.LogWarning("Driver ID: {DriverId} is not authorized to claim booking ID: {BookingId}", driverId, bookingId);
                    return false;
                }

                booking.Status = ReservationStatus.Confirmed;
                _context.TaxiBookings.Update(booking);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Driver ID: {DriverId} successfully claimed booking ID: {BookingId}", driverId, bookingId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while driver ID: {DriverId} was claiming booking ID: {BookingId}", driverId, bookingId);
                return false;
            }
        }

        
    }
}