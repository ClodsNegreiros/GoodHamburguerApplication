using Microsoft.EntityFrameworkCore;
using GoodHamburguerApplication.Domain.Interfaces;
using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.UseCases.Order;
using GoodHamburguerApplication.Infrastructure.Context;
using GoodHamburguerApplication.Infrastructure.Repositories;
using GoodHamburguerApplication.Infrastructure.Seed;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Mediator DI
            builder.Services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(
                    AppDomain.CurrentDomain.GetAssemblies()
                ));


            // Add services to the container.

            // UseCase DI
            builder.Services.AddScoped<ISendOrderUseCase, SendOrderUseCase>();
            builder.Services.AddScoped<IGetOrdersUseCase, GetOrdersUseCase>();
            builder.Services.AddScoped<IDeleteOrderUseCase, DeleteOrderUseCase>();
            builder.Services.AddScoped<IUpdateOrderUseCase, UpdateOrderUseCase>();

            builder.Services.AddScoped<IGetSandwichesUseCase, GetSandwichesUseCase>();

            // Repository DI
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ISandwichRepository, SandwichRepository>();
            builder.Services.AddScoped<IExtraRepository, ExtraRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("GoodHamburgerDb"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                InitialDataSeeder.Seed(context);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
