﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.User;

namespace WebApp.Handler
{
    public interface IUserHandler
    {
        Task<UserViewModel> GetById(Guid id);
        Task<IEnumerable<UserViewModel>> Get();
        Task<UserViewModel> Create(UserViewModel model);
        Task Update(UserViewModel model);
        Task Delete(Guid id);
        Task<IEnumerable<UserListItemViewModel>> GetAll();
    }
}