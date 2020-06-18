using System;
using System.Linq;
using AutoMapper;
using WebApp.Domain.Models;
using WebApp.ViewModels.Apartment;
using WebApp.ViewModels.Booking;
using WebApp.ViewModels.User;

namespace WebApp.ViewModels
{
    public class MappingConfig
    {
        private MapperConfiguration _config;

        public MappingConfig()
        {
        }

        public IMapper GetMapper()
        {
            CreteConfig();

            _config.AssertConfigurationIsValid();
            return _config.CreateMapper();
        }

        private void CreteConfig()
        {
            _config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserModel, UserViewModel>()
                    .ReverseMap()
                    .ConvertUsing((model, userModel) => new UserModel
                    {
                        Id = model.Id ?? new Guid(),
                        Login = model.Login,
                        PhoneNumber = model.PhoneNumber
                    });

                config.CreateMap<ApartmentModel, ApartmentViewModel>()
                    .ReverseMap()
                    .ConvertUsing((model, apartmentModel) => new ApartmentModel
                    {
                        Id = model.Id ?? new Guid(),
                        Address = model.Address,
                        Area = model.Area,
                        BookingCost = model.BookingCost,
                        CountRoom = model.CountRoom,
                        MaxCountGuests = model.MaxCountGuests
                    });

                config.CreateMap<BookingModel, BookingViewModel>()
                    .ReverseMap()
                    .ConvertUsing((model, apartmentModel) => new BookingModel
                    {
                        Id = model.Id ?? Guid.NewGuid(),
                        End = model.End,
                        Start = model.Start,
                        ApartmentId = model.ApartmentId,
                        GuestCount = model.GuestCount,
                        UserId = model.UserId
                    });

                config.CreateMap<UserModel, UserListItemViewModel>()
                    .ConvertUsing((model, viewModel) => new UserListItemViewModel
                    {
                        Apartments = model.Booking
                            .GroupBy(w => w.Apartment)
                            .OrderByDescending(w => w.Count())
                            .Select(w => w.Key.Id).Distinct().Take(5),
                        
                        Bookings = model.Booking.Select(w=> w.Id),
                        Login = model.Login,
                        PhoneNumber = model.PhoneNumber
                    });
            });
        }
    }
}