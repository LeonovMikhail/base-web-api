using BksTest.DAL.Repository;
using BksTest.DAL.Repository.Implementation;
using BksTest.Domain.Models;
using BksTest.Handler;
using BksTest.Handler.Implementation;
using BksTest.Service;
using BksTest.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BksTest
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