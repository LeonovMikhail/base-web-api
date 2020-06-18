using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.ViewModels.Apartment;
using BksTest.ViewModels.User;

namespace BksTest.Handler
{
    public interface IApartmentHandler
    {
        Task<ApartmentViewModel> GetById(Guid id);
        Task<IEnumerable<ApartmentViewModel>> GetAll();
        Task Update(ApartmentViewModel model);
        Task<ApartmentViewModel> Create(ApartmentViewModel model);
        Task Delete(Guid id);
    }
}