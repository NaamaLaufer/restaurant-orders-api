using AutoMapper;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace restaurant_orders_api.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<DishCreateUpdateDto, Dish>();
        }
    }
}