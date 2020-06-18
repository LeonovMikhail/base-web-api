﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BksTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BksTest.DAL.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Context _context;

        public BookingRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(BookingModel model)
        {
            _context.Booking.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingModel>> Get()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<BookingModel> GetById(Guid id)
        {
            return await _context.Booking.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task Update(BookingModel model)
        {
            _context.Booking.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var booking = await GetById(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<BookingModel, bool>> @where)
        {
            return _context.Booking.AnyAsync(where);
        }
    }
}