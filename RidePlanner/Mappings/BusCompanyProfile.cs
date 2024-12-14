using AutoMapper;
using RidePlanner.Models.Entities;
using RidePlanner.ViewModel.Bus;

namespace RidePlanner.Mappings
{
    public class BusCompanyProfile : Profile
    {
        public BusCompanyProfile()
        {
            CreateMap<BusCompany, BusCompanyViewModel>()
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ReverseMap();

            CreateMap<BusCompanyViewModel, BusCompany>()
                .ForMember(dest => dest.BusCompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));
        }
    }
}
