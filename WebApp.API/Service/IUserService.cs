using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.User;

namespace WebApp.Service
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