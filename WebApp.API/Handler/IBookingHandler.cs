using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.ViewModels.Booking;

namespace BksTest.Handler
{
    public interface IBookingHandler
    {
        Task<IEnumerable<BookingViewModel>> GetAll();
        Task<BookingViewModel> GetById(Guid id);
        Task Update(BookingViewModel model);
        Task<BookingViewModel> Create(BookingViewModel model);
        Task Delete(Guid id);
    }
}