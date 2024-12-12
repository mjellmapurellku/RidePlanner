using AutoMapper;
using RidePlanner.Models.DTOs;
using RidePlanner.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RidePlanner.Mappings
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}