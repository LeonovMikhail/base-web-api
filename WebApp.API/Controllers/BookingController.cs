﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.Handler;
using BksTest.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BksTest.Controllers
{
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        
        private readonly IBookingHandler _bookingHandler;

        public BookingController(IBookingHandler bookingHandler)
        {
            _bookingHandler = bookingHandler;
        }

        [HttpGet("{id}")]
        public async Task<BookingViewModel> Get([FromRoute] Guid id)
        {
            return await _bookingHandler.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<BookingViewModel>> Get()
        {
            return await _bookingHandler.GetAll();
        }

        [HttpPut]
        public async Task Update([FromBody] BookingViewModel model)
        {
            await _bookingHandler.Update(model);
        }

        [HttpPost]
        public async Task<BookingViewModel> Create([FromBody] BookingViewModel model)
        {
            return await _bookingHandler.Create(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] Guid id)
        {
            await _bookingHandler.Delete(id);
        }
    }
}