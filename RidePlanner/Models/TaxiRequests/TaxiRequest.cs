﻿namespace RidePlanner.Models.TaxiRequests
{
    public class TaxiRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the taxi.
        /// </summary>
        public int TaxiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the driver associated with the taxi.
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the license plate number of the taxi.
        /// </summary>
        public string LicensePlate { get; set; }
    }
}
