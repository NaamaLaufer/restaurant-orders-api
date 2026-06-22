using Microsoft.Extensions.DependencyInjection;
using restaurant_orders_api.Profiles;

namespace restaurant_orders_api.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(DishProfile));

            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
