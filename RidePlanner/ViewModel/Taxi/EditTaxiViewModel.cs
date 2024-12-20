﻿using RidePlanner.Models.Entities;

namespace RidePlanner.ViewModel.Taxi
{
    public class EditTaxiViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the taxi.
        /// </summary>
        public int TaxiId { get; set; }

        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the driver's name.
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the taxi company.
        /// </summary>
        public int TaxiCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the taxi information was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the list of taxi companies associated with this taxi.
        /// </summary>
        public List<TaxiCompany> TaxiCompanies { get; set; } = new List<TaxiCompany>();
    }
}
