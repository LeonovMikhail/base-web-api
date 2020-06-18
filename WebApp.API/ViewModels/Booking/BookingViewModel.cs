﻿using System;
using BksTest.Domain.Models;

namespace BksTest.ViewModels.Booking
{
    public class BookingViewModel
    {
        public Guid? Id { get; set; }
        public int GuestCount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid UserId { get; set; }
        public Guid ApartmentId { get; set; }
    }
}