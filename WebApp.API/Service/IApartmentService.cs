using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.ViewModels.Apartment;

namespace BksTest.Service
{
    public interface IApartmentService
    {
        Task<ApartmentViewModel> GetById(Guid id);
        Task<IEnumerable<ApartmentViewModel>> GetAll();
        Task Update(ApartmentViewModel model);
        Task<ApartmentViewModel> Create(ApartmentViewModel model);
        Task Delete(Guid id);
    }
}