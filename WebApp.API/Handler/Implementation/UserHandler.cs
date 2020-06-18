﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.Service;
using BksTest.ViewModels.User;

namespace BksTest.Handler.Implementation
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserService _userService;

        public UserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserViewModel> GetById(Guid id)
        {
            return await _userService.GetById(id);
        }

        public async Task<IEnumerable<UserViewModel>> Get()
        {
            return await _userService.Get();
        }

        public async Task<UserViewModel> Create(UserViewModel model)
        {
            return await _userService.Create(model);
        }

        public async Task Update(UserViewModel model)
        {
            await _userService.Update(model);
        }

        public async Task Delete(Guid id)
        {
            await _userService.Delete(id);
        }

        public async Task<IEnumerable<UserListItemViewModel>> GetAll()
        {
            return await _userService.GetAll();
        }
    }
}