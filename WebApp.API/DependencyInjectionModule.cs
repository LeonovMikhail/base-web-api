using Microsoft.Extensions.DependencyInjection;
using WebApp.DAL.Repository;
using WebApp.DAL.Repository.Implementation;
using WebApp.Domain.Models;
using WebApp.Handler;
using WebApp.Handler.Implementation;
using WebApp.Service;
using WebApp.Service.Implementation;

namespace WebApp
{
    public class DependencyInjectionModule
    {
        public static void Load(IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IApartmentHandler, ApartmentHandler>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IRepository<ApartmentModel>, ApartmentRepository>();
            
            services.AddScoped<IBookingHandler, BookingHandler>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
        }
    }
}