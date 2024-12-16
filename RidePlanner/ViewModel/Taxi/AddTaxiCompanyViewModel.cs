using RidePlanner.Models.Entities;

namespace RidePlanner.ViewModel.Taxi
{
    public class AddTaxiCompanyViewModel
    {
        /// <summary>
        /// Gets or sets the name of the taxi company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the contact information for the taxi company.
        /// </summary>
        public string ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the list of existing taxi companies.
        /// </summary>
        public List<TaxiCompany> TaxiCompanies { get; set; }

        /// <summary>
        /// Gets or sets the list of taxis associated with the company.
        /// </summary>
        public List<RidePlanner.Models.Entities.Taxi> Taxis { get; set; } // Përdorimi i emrit të plotë me hapësirën e emrit

        /// <summary>
        /// Gets or sets the ViewModel for adding a new taxi.
        /// </summary>
        public AddTaxiViewModel AddTaxiViewModel { get; set; }
    }
}
