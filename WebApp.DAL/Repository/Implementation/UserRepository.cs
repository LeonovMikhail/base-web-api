﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BksTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BksTest.DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(UserModel model)
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<UserModel> GetById(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task Update(UserModel model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetById(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<UserModel, bool>> @where)
        {
            return _context.Users.AnyAsync(where);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.Users
                .Include(w => w.Booking)
                .ThenInclude(w => w.Apartment)
                .ToListAsync();
        }
    }
}