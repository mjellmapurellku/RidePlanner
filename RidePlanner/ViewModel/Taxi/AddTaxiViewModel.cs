﻿using RidePlanner.Models.Entities;
using RidePlanner.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RidePlanner.ViewModel.Taxi
{
    public class AddTaxiViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the taxi.
        /// </summary>
        public int TaxiId { get; set; }

        /// <summary>
        /// Gets or sets the license plate (required).
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the driver's name (required).
        /// </summary>
        [Required]
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the taxi company (required).
        /// </summary>
        [Required]
        public int? TaxiCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the taxi company associated with this taxi.
        /// </summary>
        public TaxiCompany? TaxiCompany { get; set; }

        /// <summary>
        /// Gets or sets the list of available taxi companies.
        /// </summary>
        public List<TaxiCompany> TaxiCompanies { get; set; } = new List<TaxiCompany>();

        /// <summary>
        /// Gets or sets the status of the taxi using TaxiStatus enum.
        /// </summary>
        [Required]
        public TaxiStatus Status { get; set; } = TaxiStatus.Available;
    }
}