using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.Service;
using BksTest.ViewModels.Booking;

namespace BksTest.Handler.Implementation
{
    public class BookingHandler : IBookingHandler
    {
        private readonly IBookingService _bookingService;

        public BookingHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IEnumerable<BookingViewModel>> GetAll()
        {
            return await _bookingService.GetAll();
        }

        public async Task<BookingViewModel> GetById(Guid id)
        {
            return await _bookingService.GetById(id);
        }

        public async Task Update(BookingViewModel model)
        {
            await _bookingService.Update(model);
        }

        public async Task<BookingViewModel> Create(BookingViewModel model)
        {
            return await _bookingService.Create(model);
        }

        public async Task Delete(Guid id)
        {
            await _bookingService.Delete(id);
        }
    }
}