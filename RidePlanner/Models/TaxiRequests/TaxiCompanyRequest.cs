namespace RidePlanner.Models.TaxiRequests
{
    public class TaxiCompanyRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the taxi company.
        /// </summary>
        public int TaxiCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the taxi company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the contact information for the taxi company.
        /// </summary>
        public string ContactInfo { get; set; }
    }
}
