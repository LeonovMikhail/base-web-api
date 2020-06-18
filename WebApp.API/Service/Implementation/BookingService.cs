using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.DAL.Repository;
using WebApp.Domain.Models;
using WebApp.ViewModels.Booking;

namespace WebApp.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<BookingViewModel>> GetAll()
        {
            var bookings = await _bookingRepository.Get();
            return bookings.Select(w => _mapper.Map<BookingModel, BookingViewModel>(w));
        }

        public async Task<BookingViewModel> GetById(Guid id)
        {
            var booking = await _bookingRepository.GetById(id);
            return _mapper.Map<BookingModel, BookingViewModel>(booking);
        }

        public async Task Update(BookingViewModel model)
        {
            var booking = _mapper.Map<BookingViewModel, BookingModel>(model);
            await _bookingRepository.Update(booking);
        }

        public async Task<BookingViewModel> Create(BookingViewModel model)
        {
            var booking = _mapper.Map<BookingViewModel, BookingModel>(model);
            var hasUser = await _userRepository.AnyAsync(w => w.Id == booking.UserId);
            var isReserved = await _bookingRepository
                .AnyAsync(b => ((b.Start <= booking.End && b.End >= booking.End) 
                               || (b.Start <= booking.Start && b.End >= booking.Start)
                               || (booking.Start < b.Start && booking.End> b.End)) 
                               && booking.ApartmentId == b.ApartmentId);

            if (!hasUser) throw new Exception("User not found");
            if (isReserved) throw new Exception("Apartment is reserved");

            await _bookingRepository.Create(booking);
            return _mapper.Map<BookingModel, BookingViewModel>(booking);
        }

        public async Task Delete(Guid id)
        {
            await _bookingRepository.Delete(id);
        }
    }
}