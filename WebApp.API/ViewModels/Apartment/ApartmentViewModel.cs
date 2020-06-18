﻿using System;

namespace BksTest.ViewModels.Apartment
{
    public class ApartmentViewModel
    {
        public Guid? Id { get; set; } 
        public string Address { get; set; }
        public double Area { get; set; }
        public int CountRoom { get; set; }
        public int MaxCountGuests { get; set; }
        public double BookingCost { get; set; }
    }
}