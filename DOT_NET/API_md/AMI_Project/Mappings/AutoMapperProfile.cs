using AMI_Project.DTOs;
using AMI_Project.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AMI_Project.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<User, UserDto>();

           
            CreateMap<RegisterDto, User>();
        }
    }
}
