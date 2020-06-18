﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.ViewModels.User;

namespace BksTest.Service
{
    public interface IUserService
    {
        Task<UserViewModel> Create(UserViewModel model);
        Task<UserViewModel> GetById(Guid id);
        Task<IEnumerable<UserViewModel>> Get();
        Task Update(UserViewModel model);
        Task Delete(Guid id);
        Task<IEnumerable<UserListItemViewModel>> GetAll();
    }
}