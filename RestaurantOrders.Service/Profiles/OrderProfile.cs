using AutoMapper;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Models;

namespace restaurant_orders_api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderDishes));

            CreateMap<OrderDish, OrderItemDto>()
                .ForMember(dest => dest.DishName, opt => opt.MapFrom(src => src.Dish.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Dish.Price))
                .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.Dish.Price * src.Quantity));
        }
    }
}
