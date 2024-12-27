using AutoMapper;
using RidePlanner.Models.Entities;
using RidePlanner.ViewModel.BusSchedul;

namespace RidePlanner.Mappings
{
    public class BusRoutesProfile : Profile
    {
        public BusRoutesProfile()
        {
            CreateMap<AddRouteViewModel, BusRoutes>()
                .ForMember(dest => dest.RouteId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<BusRoutes, AddRouteViewModel>();
        }
    }
}