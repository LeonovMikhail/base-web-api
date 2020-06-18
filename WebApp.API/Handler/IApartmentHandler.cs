using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Apartment;

namespace WebApp.Handler
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