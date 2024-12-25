using AutoMapper;
using RidePlanner.Models.Entities;
using RidePlanner.Models.TaxiRequest;
using RidePlanner.ViewModel.TaxiModels;


namespace RidePlanner.Mappings
{
    public class TaxiCompanyProfile : Profile
    {
        public TaxiCompanyProfile()
        {
            CreateMap<TaxiCompany, TaxiCompanyViewModel>()
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ReverseMap()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.Ignore());

            CreateMap<TaxiCompanyViewModel, TaxiCompany>()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));
        }
    }
}
