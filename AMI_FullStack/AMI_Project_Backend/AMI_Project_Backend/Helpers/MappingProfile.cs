using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Models;
using AutoMapper;




namespace AMI_Project_Backend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Consumer, ConsumerDto>().ReverseMap();
            CreateMap<Meter, MeterDto>().ReverseMap();
            CreateMap<Billing, BillingDto>().ReverseMap();
        }
    }
}