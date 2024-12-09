using AutoMapper;
using Contracts.Dtos.Drink;
using Contracts.Dtos.FoodDtos;
using Contracts.Dtos.QRCodeDtos;

//using Contracts.Dtos.QRCodeDtos;
using Domain.Entities;

namespace RestaurantApplication.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Drink
            CreateMap<Drink, DrinkDto>();
            CreateMap<CreateDrinkDto, Drink>().ReverseMap();
            CreateMap<UpdateDrinkDto, Drink>().ReverseMap();

            //Food
            CreateMap<Food, FoodDto>();
            CreateMap<CreateFoodDto, Food>().ReverseMap();
            CreateMap<UpdateFoodDto, Food>().ReverseMap();

            //QRCode
            CreateMap<QRCodeEntity, QRCodeDto>()
                .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)))
                .ReverseMap();

        }
    }
}
