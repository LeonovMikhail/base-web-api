﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Booking;

namespace WebApp.Handler
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