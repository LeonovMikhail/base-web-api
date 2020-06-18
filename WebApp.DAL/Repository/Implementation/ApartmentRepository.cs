﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BksTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BksTest.DAL.Repository.Implementation
{
    public class ApartmentRepository : IRepository<ApartmentModel>
    {
        private readonly Context _context;

        public ApartmentRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ApartmentModel model)
        {
            _context.Apartments.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApartmentModel>> Get()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<ApartmentModel> GetById(Guid id)
        {
            return await _context.Apartments.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task Update(ApartmentModel model)
        {
            _context.Apartments.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var apartments = await GetById(id);
            _context.Apartments.Remove(apartments);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<ApartmentModel, bool>> @where)
        {
            return _context.Apartments.AnyAsync(where);
        }
    }
}