using AutoMapper;
using RidePlanner.Models.Entities;
using RidePlanner.ViewModel.Taxi;
using RidePlanner.Models.TaxiRequests;

namespace RidePlanner.Mappings
{
    public class TaxiProfile : Profile
    {
        public TaxiProfile()
        {
            CreateMap<Taxi, AddTaxiViewModel>()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.MapFrom(src => src.TaxiCompanyId))
                .ReverseMap()
                .ForMember(dest => dest.TaxiId, opt => opt.Ignore())
                .ForMember(dest => dest.TaxiCompany, opt => opt.Ignore());

            CreateMap<Taxi, EditTaxiViewModel>()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.MapFrom(src => src.TaxiCompanyId))
                .ReverseMap()
                .ForMember(dest => dest.TaxiId, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Taxi, TaxiRequest>();

        }
    }
}
