using Microsoft.EntityFrameworkCore;
using MediatR;
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
                    typeof(Program).Assembly
                ));


            // Add services to the container.

            // UseCase DI
            builder.Services.AddScoped<ISendOrderUseCase, SendOrderUseCase>();

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


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
