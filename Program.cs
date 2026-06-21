using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using restaurant_orders_api.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<restaurant_orders_api.Repositories.IOrderRepository, restaurant_orders_api.Repositories.OrderRepository>();
builder.Services.AddScoped<restaurant_orders_api.Services.IOrderService, restaurant_orders_api.Services.OrderService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => { }, typeof(Program)); 
builder.Services.AddScoped<restaurant_orders_api.Repositories.IDishRepository, restaurant_orders_api.Repositories.DishRepository>();
builder.Services.AddScoped<restaurant_orders_api.Services.IDishService, restaurant_orders_api.Services.DishService>();
builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<restaurant_orders_api.Middleware.ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
