using AutoMapper;
using RidePlanner.Models.Entities;
using RidePlanner.ViewModel.Authenticate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RidePlanner.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Map User entity to RegisterViewModel and EditUserViewModel
            CreateMap<User, RegisterViewModel>().ReverseMap();
            CreateMap<User, EditUserViewModel>().ReverseMap();
        }
    }
}