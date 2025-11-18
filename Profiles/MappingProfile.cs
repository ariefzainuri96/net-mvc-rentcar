using AutoMapper;
using RentCar.Models.Entity;
using RentCar.Models.Request;

namespace RentCar.Profiles {
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CarEntity, CarRequest>();
            CreateMap<CarRequest, CarEntity>();   
            // CreateMap<RentEntity, RentRequestDto>();
            // CreateMap<RentRequestDto, RentEntity>();       
        }
    }
}