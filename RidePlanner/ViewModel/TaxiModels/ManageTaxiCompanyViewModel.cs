using RidePlanner.ViewModel.TaxiModels;
using System.Collections.Generic;

namespace RidePlanner.ViewModel.Taxi
{
    public class ManageTaxiCompanyViewModel
    {
        public List<TaxiCompanyViewModel> TaxiCompanies { get; set; } = new List<TaxiCompanyViewModel>();
    }
}
