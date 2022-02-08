using AutoMapper;
using PcService.Models.DTO;
using PcService.Models.Requests;
using PcService.Models.Responses;

namespace PcService.Host.Extensions
{
    public class AutoMapping : Profile
    {      
            public AutoMapping()
            {
            CreateMap<Buyer, BuyerResponse>();
            CreateMap<BuyerRequest, Buyer>();

            CreateMap<Laptop, LaptopResponse>();
            CreateMap<LaptopRequest, Laptop>();

            CreateMap<PersonalComputer, PersonalComputerResponse>();
            CreateMap<PersonalComputerRequest, PersonalComputer>();                
            }        
    }
}
